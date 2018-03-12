using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PR_Lab2
{
    class Categories
    {
        private static string _url = "https://evil-legacy-service.herokuapp.com/api/v101/categories/";
        private static string CategoryFilePath = "C:\\EvilApp\\Category.txt";
        private static CsvParser<Category> _parser;

        static Categories()
        {
            _parser = new CsvParser<Category>(new Category());
        }

        public static async Task Get(IProgress<List<Category>> progress)
        {
            var remoteResult = await GetRemote();
            if (remoteResult == null)
            {
                var local = GetLocal();
                if (local != null)
                {
                    progress.Report(local);
                    return;
                }
            }
            else
            {
                progress.Report(remoteResult);
                return;
            }

            progress.Report(new List<Category>());
        }

        private static async Task<List<Category>> GetRemote()
        {
            var response = await HttpUtil.PerformGetRequest(_url);
            if (response.status == HttpStatusCode.OK)
            {
                SaveToDisk(response.data);
                return _parser.ToList(response.data);
            }
            return null;
        }

        private static List<Category> GetLocal()
        {
            try
            {
                var file = new FileInfo(CategoryFilePath);
                if (!file.Exists)
                {
                    return null;
                }

                using (var stream = file.OpenText())
                {
                    var csv = stream.ReadToEnd();
                    return _parser.ToList(csv);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Fail to read " + CategoryFilePath + " : " + e.Message);
                return null;
            }
        }

        private static void SaveToDisk(string csv)
        {
            var file = new FileInfo(CategoryFilePath);

            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }

            using (var stream = file.CreateText())
            {
                foreach (var line in csv.Split('\n'))
                {
                    stream.WriteLine(line);
                }
            }
        }


    }
}
