using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SocialNetwork.Graph.Models;

namespace SocialNetwork.Graph.Infrastructure
{
    public static class FileReader
    {
        public static async Task<IList<User>> GetUsersAsync()
        {
            var filePath = HttpContext.Current.Server.MapPath("~") + "..\\users.json";
            using (var streamReader = new StreamReader(filePath))
            {
                var json = await streamReader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<IList<User>>(json);
            }
        }
    }
}