using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gremlin.Net.Driver;
using Gremlin.Net.Structure.IO.GraphSON;
using SocialNetwork.Graph.Models;
using User = SocialNetwork.Graph.Models.User;

namespace SocialNetwork.Graph.Infrastructure
{
    public class GraphClientWrapper
    {
        private const string EndpointUrl = "diplom.gremlin.cosmos.azure.com";
        private const int Port = 443;
        private const string Database = "SocialNetwork";
        private const string Collection = "SocialNetwork";
        private const string PrimaryKey = "VOCMv4Up6O1DTeLruHLuoTMITyIffwms16wGJNMiIsKGnPuU9hf1fuNza61wU0Bp6DD4ZBy8XYmOFQI6Oug6qw==";

        private readonly GremlinClient _gremlinClient;

        public GraphClientWrapper()
        {
            var gremlinServer = new GremlinServer(EndpointUrl,
                Port, true, "/dbs/" + Database + "/colls/" + Collection, PrimaryKey);
            _gremlinClient = new GremlinClient(gremlinServer, new GraphSON2Reader(),
                new GraphSON2Writer(), GremlinClient.GraphSON2MimeType);
        }

        public async Task ClearAsync()
        {
            var query = "g.V().drop()";
            await _gremlinClient.SubmitAsync(query);
        }

        public async Task CreateUserAsync(User user)
        {
            var query = $"g.addV().property('id', '{user.Id}')"
                           + $".property('firstName', '{user.FirstName}')"
                           + $".property('lastName', '{user.LastName}')";

            await _gremlinClient.SubmitAsync(query);
        }

        public async Task CreateRelationshipAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (user.Relationships == null)
                return;

            foreach (var relationship in user.Relationships)
            {
                var query = $"g.V('{user.Id}').addE('{relationship.Type}').to(g.V('{relationship.ToUserId}'))";
                await _gremlinClient.SubmitAsync(query);
            }
        }

        public async Task<IList<Node>> GetNodesAsync(int userId, int n)
        {
            var result = new List<Node>();
            var query = $"g.V('{userId}').emit().repeat(bothE().otherV().barrier()).times({n}).dedup()";
            var response = await _gremlinClient.SubmitAsync<dynamic>(query);

            foreach (var item in response)
            {
                var properties = item["properties"];

                var firstName = (Dictionary<string, object>)((IEnumerable<object>)properties["firstName"]).First();
                var lastName = (Dictionary<string, object>)((IEnumerable<object>)properties["lastName"]).First();

                result.Add(new Node()
                {
                    Id = Convert.ToInt32(item["id"]),
                    Value = (string)firstName["value"] + " " + (string)lastName["value"]
                });
            }

            return result;
        }

        public async Task<IEnumerable<Edge>> GetEdgesAsync(IEnumerable<int> nodeIds)
        {
            var ids = string.Join(",", nodeIds.Select(x => $"'{x}'"));
            var query = $"g.E().where(inV().hasId(within({ids})).and().outV().hasId(within({ids})))";
            var response = await _gremlinClient.SubmitAsync<dynamic>(query);

            return response.Select(item => new Edge()
            {
                ToId = Convert.ToInt32(item["inV"]),
                FromId = Convert.ToInt32(item["outV"]),
                Label = item["label"]
            });
        }
    }
}