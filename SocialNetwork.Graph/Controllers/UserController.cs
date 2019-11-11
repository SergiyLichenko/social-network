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
        public async Task<string> GetNthDescendants([FromUri] int n)
        {
            if (n <= 0 || n > 3) throw new ArgumentOutOfRangeException(nameof(n));

            await _userService.GetNthDescendantsAsync(n);
            
            return null;
        }
    }
}