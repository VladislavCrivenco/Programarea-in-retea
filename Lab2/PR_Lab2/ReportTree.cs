using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CommonTools;

namespace PR_Lab2
{
    class ReportTree : TreeListView
    {
        //protected override object GetData(Node node, TreeListColumn column)
        //{
        //    object data = base.GetData(node, column);
        //    if (data != null)
        //        return data;

        //    if (column.Fieldname == "total")
        //    {
        //        return node[1];
        //    }
        //    return "noData";
        //}

        public async Task InitAsync()
        {
            var progress = new Progress<List<Category>>(s => Init(s));
            await Categories.Get(progress);
        }

        private void Init(List<Category> list)
        {
            BeginUpdate();
            FillLevel(list, null);
            EndUpdate();
        }

        public async Task RefreshAsync(DateTime from, DateTime to)
        {
            var progress = new Progress<CategoryOrdersView>(s => Refresh(s));
            await CategoryOrdersView.GetInstanceAsync(progress);
        }

        private void Refresh(CategoryOrdersView categoryOrders)
        {
            BeginUpdate();

            foreach (var rootNode in Nodes)
            {
                RefreshNode(rootNode as Node, categoryOrders);
            }

            EndUpdate();
        }

        private float RefreshNode(Node node, CategoryOrdersView orders)
        {
            if (node == null)
            {
                Debugger.Break();
                return 0;
            }
            if (!node.HasChildren)
            {
                var total = orders.Get(node[2]);
                node[1] = total.ToString();
                return total;
            }
            float sum = 0;
            foreach (var child in node.Nodes)
            {
                sum += RefreshNode(child as Node, orders);
            }

            node[1] = sum.ToString();
            return sum;
        }

        private void FillLevel(List<Category> allCategories, List<(Node node, Category category)> currentLevel)
        {
            Debug.Assert(allCategories != null, "Fill Level with no categories");
            if (currentLevel == null)
            {
                var firstCategories = allCategories.Where(x => x.ParentId == null).ToList();
                currentLevel = new List<(Node, Category)>();
                foreach (var rootCategory in firstCategories)
                {
                    var rootNode = new Node(new object[] { rootCategory.ToString(), null, rootCategory.Id });
                    this.Nodes.Add(rootNode);

                    allCategories.Remove(rootCategory);
                    currentLevel.Add((rootNode, rootCategory));
                }

                FillLevel(allCategories, currentLevel);
                return;
            }

            if (allCategories.Count == 0 || currentLevel.Count == 0)
            {
                Debug.WriteLine("Finished Parsing");
                return;
            }

            var nextLevel = new List<(Node, Category)>();
            foreach (var cat in currentLevel)
            {
                var childrenCategories = allCategories.Where(x => x.ParentId.Equals(cat.category.Id)).ToList();
                foreach (var category in childrenCategories)
                {
                    var categoryNode = new Node(new object[] { category.ToString(), null, category.Id });
                    cat.node.Nodes.Add(categoryNode);
                    nextLevel.Add((categoryNode, category));
                }

                allCategories.Remove(cat.category);
            }

            //Debugger.Break();
            FillLevel(allCategories, nextLevel);
        }
    }
}
