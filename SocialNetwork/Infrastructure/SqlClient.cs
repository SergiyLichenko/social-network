using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocialNetwork.Models;

namespace SocialNetwork.Infrastructure
{
    public class SqlClient
    {
        private const string BaseUrl = "https://localhost:44386/api/";

        public async Task<IEnumerable<User>> GetAllAsync(string query)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(BaseUrl + "user/getAll", stringContent);
                var responseString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<User>>(responseString);
            }
        }

        public async Task<User> GetByIdAsync(string query)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(BaseUrl + "user/getById", stringContent);
                var responseString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<User>(responseString);
            }
        }
    }
}