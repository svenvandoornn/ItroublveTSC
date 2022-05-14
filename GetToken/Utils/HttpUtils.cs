using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StealerExt
{
    internal class HttpUtils
    {
        private static HttpClientHandler handler = new HttpClientHandler() { UseProxy = false };
        public static HttpClient client = new HttpClient(handler);

        public async Task<string> GetAsync(string url, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
        
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
        
        public async Task<string> PostAsync(string url, object jsonBody, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
            var content = new StringContent(JsonConvert.SerializeObject(jsonBody), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
