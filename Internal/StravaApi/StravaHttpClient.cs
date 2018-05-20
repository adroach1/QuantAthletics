using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StravaApi.StravaModel;

namespace StravaApi
{
    public class StravaHttpClient
    {
        private readonly HttpClient _client;
        public StravaHttpClient()
        {
            _client = new HttpClient();
        }
        public async Task<T> PostStravaRequest<T>(StravaRequestItem requestItem)
        {
            var requestJson = JsonConvert.SerializeObject(requestItem);
            var httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(requestItem.RequestUrl, httpContent);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }
    }
}