using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetwork.MediaFile.Models;
using SocialNetwork.MediaFile.Services;

namespace SocialNetwork.MediaFile.Controllers
{
    [RoutePrefix("api/mediaFile")]
    public class MediaFileController : ApiController
    {
        private readonly MediaFileService _mediaFileService;

        public MediaFileController()
        {
            _mediaFileService = new MediaFileService();
        }

        [HttpGet]
        [Route("byUserId")]
        public async Task<IEnumerable<ImageInfo>> GetByUserId([FromUri] int userId)
        {
            if (userId <= 0)
                throw new ArgumentOutOfRangeException(nameof(userId));

            return await _mediaFileService.GetByUserId(userId);
        }

        [HttpGet]
        [Route("byName")]
        public async Task<IHttpActionResult> GetByNameAsync([FromUri] string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException(nameof(fileName));

            var memoryStream = await _mediaFileService.GetByNameAsync(fileName);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
                { Content = new ByteArrayContent(memoryStream.GetBuffer()) };
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
               { FileName = fileName };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return ResponseMessage(result);
        }

        [HttpGet]
        [Route("byTag")]
        public async Task<IEnumerable<ImageInfo>> GetByTagAsync([FromUri] string tag)
        {
            if(string.IsNullOrWhiteSpace(tag))
                throw new ArgumentException(nameof(tag));

            return await _mediaFileService.GetByTagAsync(tag);
        }

        [HttpGet]
        [Route("query")]
        public async Task<IEnumerable<ImageInfo>> QueryImagesAsync([FromUri] Query query)
        {
            if(query == null) throw new ArgumentNullException(nameof(query));

            return await _mediaFileService.QueryImagesAsync(query);
        }
    }
}