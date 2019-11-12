using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.Infrastructure;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public class UserService
    {
        private readonly SqlClient _sqlClient;
        private readonly MediaClient _mediaClient;
        private readonly GraphClient _graphClient;

        public UserService()
        {
            _sqlClient = new SqlClient();
            _mediaClient = new MediaClient();
            _graphClient = new GraphClient();
        }

        public async Task<IEnumerable<User>> GetAllAsync(string query)
            => await _sqlClient.GetAllAsync(query);

        public async Task<User> GetByIdAsync(string query)
        {
            var user = await _sqlClient.GetByIdAsync(query);
            user.Images = await _mediaClient.GetByUserId(user.Id);
            user.Graph = await _graphClient.GetNthDescendants(user.Id);

            return user;
        }
    }
}