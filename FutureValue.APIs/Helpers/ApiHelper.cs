using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FutureValue.APIs.Helpers
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://localhost:44362/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); //add headers to get json to parse it with models
        }
    }
}
