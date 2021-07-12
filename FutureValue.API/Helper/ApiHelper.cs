using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FutureValue.API.Helper
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient(string url)
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(url);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); //add headers to get json to parse it with models
        }
    }
}
