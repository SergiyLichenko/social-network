using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Graph.Infrastructure;

namespace SocialNetwork.Graph.Services
{
    public class UserService
    {
        private readonly GraphClientWrapper _graphClientWrapper;

        public UserService()
        {
            _graphClientWrapper = new GraphClientWrapper();
        }

        public async Task<Models.Graph> GetNthDescendantsAsync(int userId, int n)
        {
            var nodes = await _graphClientWrapper.GetNodesAsync(userId, n);
            var edges = await _graphClientWrapper.GetEdgesAsync(nodes.Select(x => x.Id));

            return new Models.Graph()
            {
                Nodes = nodes,
                Edges = edges
            };
        }

        public async Task InitializeAsync()
        {
            var users = await FileReader.GetUsersAsync();

            await _graphClientWrapper.ClearAsync();
            foreach (var user in users)
                await _graphClientWrapper.CreateUserAsync(user);
            foreach (var user in users)
                await _graphClientWrapper.CreateRelationshipAsync(user);
        }
    }
}