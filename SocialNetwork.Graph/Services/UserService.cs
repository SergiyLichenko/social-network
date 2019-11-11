using System;
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

        public async Task GetNthDescendantsAsync(int n)
        {
            await _graphClientWrapper.ExecuteAsync();
        }
    }
}