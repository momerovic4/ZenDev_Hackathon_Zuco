namespace ZucoBiH.Helper
{
    public class GarbageDetector
    {
        static HttpClient client = new HttpClient();

        public async Task<bool> DetectGarbage(string imag64)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/", imag64);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.IsSuccessStatusCode;
        }
    }
}
