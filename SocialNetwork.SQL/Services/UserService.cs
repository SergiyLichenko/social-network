using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Net;
using Newtonsoft.Json;
using SocialNetwork.SQL.Models;
using SocialNetwork.SQL.Repositories;

namespace SocialNetwork.SQL.Services
{
    public class UserService
    {
        private readonly GraphQL<SocialNetworkContext> _graphQl;

        public UserService()
        {
            var schema = GraphQL<SocialNetworkContext>.CreateDefaultSchema(() => new SocialNetworkContext());

            var userType = schema.AddType<User>();
            userType.AddAllFields();
            schema.AddListField("users", new { ids = new List<int>() }, (db, args) => db.Users.Where(x=>args.ids.Contains(x.Id)));
            schema.AddField("user", new { id = 0 }, (db, args) => db.Users.FirstOrDefault(x => x.Id == args.id));

            schema.Complete();
            _graphQl = new GraphQL<SocialNetworkContext>(schema);
        }

        public async Task<IEnumerable<User>> GetAllAsync(string query)
        {
            var queryResult = await Task.Run(() => _graphQl.ExecuteQuery(query));
            var serializedResult = JsonConvert.SerializeObject(queryResult["users"], Formatting.Indented);
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(serializedResult);

            return users;
        }

        public async Task<User> GetByIdAsync(string query)
        {
            var queryResult = await Task.Run(() => _graphQl.ExecuteQuery(query));
            var serializedResult = JsonConvert.SerializeObject(queryResult["user"], Formatting.Indented);
            var user = JsonConvert.DeserializeObject<User>(serializedResult);

            return user;
        }
    }
}