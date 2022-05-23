using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StealerExt
{
    internal class HttpUtils
    {
        private static readonly HttpClientHandler handler = new HttpClientHandler
        {
            UseProxy = false
        };
        public HttpClient client = new HttpClient(handler);
        
        public async Task<string> GetStringAsync(string url, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
            return await client.GetStringAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent httpContent, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
            return await client.PostAsync(url, httpContent);
        }
    }
}