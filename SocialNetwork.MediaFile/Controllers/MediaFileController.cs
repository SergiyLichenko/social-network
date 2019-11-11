using System.Web.Http;

namespace SocialNetwork.MediaFile.Controllers
{
    [RoutePrefix("api/mediaFile")]
    public class MediaFileController : ApiController
    {
        [HttpGet]
        [Route("byUserId")]
        public void GetByUserId([FromUri] int userId)
        {

        }
    }
}