using System.Threading.Tasks;
using System.Web.Http;

namespace SocialNetwork.Graph.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController:ApiController
    {
        [Route("descendants")]
        [HttpGet]
        public async Task<string> GetNthDescendants([FromUri] int n)
        {
            return "Ok";
        }
    }
}