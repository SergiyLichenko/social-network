using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Neo4jClient;
using SocialNetwork.Graph.Models;

namespace SocialNetwork.Graph.Infrastructure
{
    public class GraphClientWrapper
    {
        private readonly GraphClient _graphClient;

        public GraphClientWrapper()
        {
            _graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "SocialNetwork");
            _graphClient.Connect();
        }

        public async Task ExecuteAsync()
        {
            await Initialize();
        }

        public async Task Initialize()
        {
            var newUser1 = new User()
            {
                Id = 1,
                FirstName = "Serhii",
                LastName = "Lichenko"
            };
            var newUser2 = new User()
            {
                Id = 2,
                FirstName = "Lera",
                LastName = "Gaistruk"
            };

            await CreateUserAsync(newUser1);
            await CreateUserAsync(newUser2);

            await CreateRelationshipAsync(new UserRelationship() { FromId = 2, ToId = 1 });
        }

        private async Task CreateUserAsync(User newUser)
        {
            await _graphClient.Cypher
                        .Create("(user:User {newUser})")
                        .WithParam("newUser", newUser)
                        .ExecuteWithoutResultsAsync();
        }

        private async Task CreateRelationshipAsync(UserRelationship userRelationship)
        {
            await _graphClient.Cypher
                       .Match("(user1:User)", "(user2:User)")
                       .Where((User user1) => user1.Id == userRelationship.FromId)
                       .AndWhere((User user2) => user2.Id == userRelationship.ToId)
                       .Create("user1-[:FRIENDS_WITH]->user2")
                       .ExecuteWithoutResultsAsync();
        }
    }
}