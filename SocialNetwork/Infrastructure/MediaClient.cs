using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocialNetwork.Models;

namespace SocialNetwork.Infrastructure
{
    public class MediaClient
    {
        private const string BaseUrl = "https://localhost:44375/api/";

        public async Task<IEnumerable<ImageInfo>> GetByUserId(int userId)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(BaseUrl + "mediaFile/byUserId?userId="+userId);
                var responseString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<ImageInfo>>(responseString);
            }
        }
    }
}