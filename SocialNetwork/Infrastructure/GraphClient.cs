using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocialNetwork.Models;

namespace SocialNetwork.Infrastructure
{
    public class GraphClient
    {
        private const string BaseUrl = "https://localhost:44305/api/";
        private const int DefaultDepth = 2;

        public async Task<Models.Graph> GetNthDescendants(int userId)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(BaseUrl + "user/descendants?userId=" + userId + "&n=" + DefaultDepth);
                var responseString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Graph>(responseString);
            }
        }
    }
}