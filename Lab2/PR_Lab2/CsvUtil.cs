using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Lab2
{
    class CsvUtil
    {
        public static List<Category> CategoriesFromCsv(string csv)
        {
            var result = new List<Category>();
            var lines = csv.Split('\n');
            for (int i = 1; i < lines.Length; i++)
            {
                var category = Category.Parse(lines[i]);
                if (category != null)
                {
                    result.Add(category);
                }
            }
            return result;
        }

        public static List<Order> OrdersFromCsv(string csv)
        {
            var result = new List<Order>();
            var lines = csv.Split('\n');
            for (int i = 1; i < lines.Length; i++)
            {
                var order = Order.Parse(lines[i]);
                if (order != null)
                {
                    result.Add(order);
                }
            }
            return result;
        }
    }
}
