using System;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetwork.Graph.Services;

namespace SocialNetwork.Graph.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        [Route("descendants")]
        [HttpGet]
        public async Task<Models.Graph> GetNthDescendants([FromUri] int userId, [FromUri] int n)
        {
            if (n <= 0 || n > 3) throw new ArgumentOutOfRangeException(nameof(n));

            return await _userService.GetNthDescendantsAsync(userId, n);
        }

        [Route("initialize")]
        [HttpPost]
        public async Task InitializeAsync()
        {
            await _userService.InitializeAsync();
        }
    }
}