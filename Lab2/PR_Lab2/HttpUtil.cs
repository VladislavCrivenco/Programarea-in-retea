using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PR_Lab2
{
    public class HttpUtil
    {

        private static HttpClient _client;

        static HttpUtil()
        {
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromMinutes(1);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/csv"));
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-api-key", "55193451-1409-4729-9cd4-7c65d63b8e76");
            _client.DefaultRequestHeaders.Add("x-api-key", "55193451-1409-4729-9cd4-7c65d63b8e76");
        }

        public static async Task<(HttpStatusCode status, string data)> PerformGetRequest(String url)
        {
            try
            {
                var responseMessage = await _client.GetAsync(url);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseString = await responseMessage.Content.ReadAsStringAsync();
                    return (HttpStatusCode.OK, responseString);
                }
                else
                {
                    Debug.WriteLine(responseMessage.StatusCode + " :" + responseMessage.ReasonPhrase);
                    return (HttpStatusCode.BadRequest, null);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("PerformGetRequest for url " + url + " , got exception " + e.Message);
                return (HttpStatusCode.InternalServerError, null);
            }
            finally
            {
                Debug.WriteLine("HTTP GET REQUEST: " + url);
            }
        }

        public static async Task<(HttpStatusCode status, string data)> PerformGetRequest(String url, Dictionary<String, String> parameters)
        {
            String paramsString = GetUrlEncodedParameterString(parameters);
            if (paramsString?.Length > 0)
            {
                url += "?" + paramsString;
            }
            return await PerformGetRequest(url);
        }

        private static String GetUrlEncodedParameterString(Dictionary<String, String> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return "";

            StringBuilder sb = new StringBuilder(parameters.Count * 20);

            foreach (var parameter in parameters)
            {
                sb.Append(HttpUtility.UrlEncode(parameter.Key));
                sb.Append("=");
                sb.Append(HttpUtility.UrlEncode(parameter.Value));
                sb.Append("&");
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }


}