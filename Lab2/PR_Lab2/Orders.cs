using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PR_Lab2
{
    class Orders
    {
        private static string _url = "https://evil-legacy-service.herokuapp.com/api/v101/orders/";
        private static string OrderFilePath = "C:\\EvilApp\\Orders.txt";
        private static CsvParser<Order> _parser;

        static Orders()
        {
            _parser = new CsvParser<Order>(new Order());
        }
        public static async Task Get(IProgress<List<Order>> progress, DateTime from, DateTime to)
        {
            var result = new List<Order>();
            var remoteResult = await GetRemote(from, to);
            if (remoteResult == null)
            {
                var local = GetLocal(from, to);
                if (local != null)
                {
                    result = local;
                }
            }
            else
            {
                result = remoteResult;
            }

            progress.Report(result);
        }

        private static async Task<List<Order>> GetRemote(DateTime from, DateTime to)
        {
            var response = await HttpUtil.PerformGetRequest(_url,
                new Dictionary<string, string>
                {
                    ["start"] = String.Format("{0:yyyy-MM-dd}", from),
                    ["end"] = String.Format("{0:yyyy-MM-dd}", to)
                });

            if (response.status == HttpStatusCode.OK)
            {
                var result = _parser.ToList(response.data);
                UpdateDisk(result);
                return result;
            }
            return null;
        }

        private static List<Order> GetLocal(DateTime from, DateTime to)
        {
            var allCategories = GetLocal();
            if (allCategories == null)
            {
                return null;
            }

            return allCategories.Where(x => x.CreatedAt.Date >= from && x.CreatedAt.Date <= to).ToList();
        }

        private static List<Order> GetLocal()
        {
            try
            {
                var file = new FileInfo(OrderFilePath);
                if (!file.Exists)
                {
                    return null;
                }

                using (var stream = file.OpenText())
                {
                    var json = stream.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Order>>(json);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Fail to read " + OrderFilePath + " : " + e.Message);
                return null;
            }
        }

        private static void UpdateDisk(List<Order> newCategories)
        {
            var cachedCategories = GetLocal();
            List<Order> merge;
            if (cachedCategories == null)
            {
                merge = newCategories;
            }
            else
            {
                merge = newCategories.Union(cachedCategories).ToList();
            }

            SaveToDisk(merge);
        }

        private static void SaveToDisk(List<Order> list)
        {
            var file = new FileInfo(OrderFilePath);

            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }

            using (var stream = file.CreateText())
            {
                new JsonSerializer().Serialize(stream, list);
            }
        }
    }
}
