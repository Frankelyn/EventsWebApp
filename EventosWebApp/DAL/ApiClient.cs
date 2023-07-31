using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace EventosWebApp.DAL
{
    public class ApiClient
    {
        private HttpClient httpClient = new HttpClient();
        public string baseURL = "http://localhost:8000/"; //URL de la API

        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            string url = baseURL + endpoint;
            return await httpClient.GetAsync(url);
        }

        public async Task<HttpResponseMessage> GetByIdAsync(string endpoint, int id)
        {
            string url = baseURL + $"{endpoint}/{id}";
            return await httpClient.GetAsync(url);
        }


        public async Task<HttpResponseMessage> PutAsync<T>(string endpoint, T data)
        {
            string url = baseURL + endpoint;
            string jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            return await httpClient.PutAsync(url, content);
        }
    }
}
