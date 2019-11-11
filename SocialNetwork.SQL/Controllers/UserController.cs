using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetwork.SQL.Repositories.Models;
using SocialNetwork.SQL.Services;

namespace SocialNetwork.SQL.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        [Route("getAll")]
        [HttpPost]
        public async Task<IEnumerable<User>> GetAllAsync([FromBody] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException(nameof(query));

            return await _userService.GetAllAsync(query);
        }

        [Route("getById")]
        [HttpPost]
        public async Task<User> GetByIdAsync([FromBody] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException(nameof(query));

            return await _userService.GetByIdAsync(query);
        }
    }
}