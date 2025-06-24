using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WinFormsCupones.Helpers
{
    public static class HttpHelper
    {
        private static readonly HttpClient _client = new HttpClient();

        static HttpHelper()
        {
            _client.BaseAddress = new Uri("https://localhost:5001/");
        }

        public static HttpClient Client
        {
             get
             {
                 if (!string.IsNullOrEmpty(FormLogin.Token))
                 {
                     _client.DefaultRequestHeaders.Authorization =
                     new AuthenticationHeaderValue("Bearer", FormLogin.Token);
                 }

                 return _client;
             }
        }
    }
}

