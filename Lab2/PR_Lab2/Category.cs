using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PR_Lab2
{
    class Category : ICsvParseble<Category>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Category s)
            {
                return Id == s.Id;
            }

            return false;
        }

        public override string ToString()
        {
            return Name ?? "DefaultCategory";
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public Category Parse(string csvLine)
        {
            var elems = csvLine.Split(',');
            try
            {
                if (elems.Length != 3 && elems.Length != 2)
                {
                    throw new ArgumentException("Invalid csv format");
                }

                var idSuccess = int.TryParse(elems[0], out int id);
                if (!idSuccess)
                {
                    throw new ArgumentException("Invalid id argument");
                }

                var name = elems[1];
                if (elems.Length == 2 || string.IsNullOrWhiteSpace(elems[2]))
                {
                    return new Category
                    {
                        Id = id.ToString(),
                        Name = name,
                        ParentId = null
                    };
                }
                else
                {
                    var categoryIdSuccess = int.TryParse(elems[2], out int categoryId);
                    if (!categoryIdSuccess)
                    {
                        throw new ArgumentException("Invalid categoryId argument");
                    }

                    return new Category
                    {
                        Id = id.ToString(),
                        Name = name,
                        ParentId = categoryId.ToString()
                    };
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Fail to parse {0} to Order object : {1}", csvLine, e.Message);
                return null;
            }
        }
    }
}
