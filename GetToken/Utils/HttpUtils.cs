using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
        
        public async Task<HttpResponseMessage> PostAsync(string url, object jsonBody, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
            var content = new StringContent(JsonConvert.SerializeObject(jsonBody), Encoding.UTF8, "application/json");
            return await client.PostAsync(url, content);
        }
    }
}