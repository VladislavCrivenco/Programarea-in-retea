using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Lab2
{
    class Order : ICsvParseble<Order>
    {
        public string Id { get; set; }
        public float Total { get; set; }
        public string CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Order Parse(string csvLine)
        {
            var elems = csvLine.Split(',');
            try
            {
                if (elems.Length != 4)
                {
                    throw new ArgumentException("Invalid csv format");
                }

                var id = elems[0];
                var totalSucces = float.TryParse(elems[1], NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out float total);
                if (!totalSucces)
                {
                    throw new ArgumentException("Invalid total argument");
                }

                var category = elems[2];
                var categorySuccess = int.TryParse(category, out int categoryId);
                if (!categorySuccess)
                {
                    throw new ArgumentException("Invalid categoryId argument");
                }

                var createdSuccess = DateTime.TryParse(elems[3], out DateTime created);
                if (!createdSuccess)
                {
                    throw new ArgumentException("Invalid created argument");
                }

                return new Order
                {
                    Id = id,
                    Total = total,
                    CategoryId = category,
                    CreatedAt = created
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine("Fail to parse {0} to Order object : {1}", csvLine, e.Message);
                return null;
            }
        }
}
}
