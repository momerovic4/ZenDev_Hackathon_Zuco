using Nancy.Json;
using System.Text;

namespace ZucoBiH.Helper
{
    public class GarbageDetector
    {
        static HttpClient client = new HttpClient();

        public async Task<string> DetectGarbage(string imag64)
        {

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { slika = imag64 });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("http://34.232.16.103:80/api/obradisliku", content);
            string resultContent = await result.Content.ReadAsStringAsync();

            var aiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AIResponse>(resultContent);

            return aiResponse.slika;
        }


    }

    public class AIResponse
    {
        public string slika { get; set; }
        public string spisakObjekata { get; set; }
    }
}
