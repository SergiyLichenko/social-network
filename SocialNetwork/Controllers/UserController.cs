using System.Web.Http;

namespace SocialNetwork.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [Route("getAll")]
        [HttpGet]
        public string Get()
        {
            return "s";
        }
    }
}