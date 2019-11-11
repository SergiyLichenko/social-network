using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.Infrastructure;
using SocialNetwork.Models;

namespace SocialNetwork.Services
{
    public class UserService
    {
        private readonly SqlClient _sqlClient;

        public UserService()
        {
            _sqlClient = new SqlClient();
        }

        public async Task<IEnumerable<User>> GetAllAsync(string query)
            => await _sqlClient.GetAllAsync(query);

        public async Task<User> GetByIdAsync(string query)
        {
            var result = await _sqlClient.GetByIdAsync(query);

            return result;
        }
    }
}