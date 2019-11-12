using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SocialNetwork.SQL.Models;

namespace SocialNetwork.SQL.Infrastructure
{
    public static class FileReader
    {
        public static async Task<IList<User>> GetUsersAsync()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "..\\users.json";
            using (var streamReader = new StreamReader(filePath))
            {
                var json = await streamReader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<IList<User>>(json);
            }
        }
    }
}