using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SocialNetwork.MediaFile.Infrastructure;
using SocialNetwork.MediaFile.Models;

namespace SocialNetwork.MediaFile.Services
{
    public class MediaFileService
    {
        private readonly string BaseFolderPath;

        public MediaFileService()
        {
            BaseFolderPath = Path.Combine(HttpContext.Current.Server.MapPath("~"), "Database");
        }

        public async Task<IEnumerable<ImageInfo>> GetByUserId(int userId)
        {
            var fileInfos = await Task.Run(() =>
            {
                var files = Directory.GetFiles(BaseFolderPath)
                                .Select(x => new Bitmap(x)).ToList();

                var result = files.Select(x => new ImageInfo()
                {
                    UserId = x.GetAuthorId(),
                    Tags = x.GetTags(),
                    Image = (Image)x.Clone()
                }).Where(x => x.UserId == userId).ToList();

                files.ForEach(x => x.Dispose());
                return result;
            });

            return fileInfos;
        }

        public async Task<MemoryStream> GetByNameAsync(string fileName)
        {
            var file = Directory.GetFiles(BaseFolderPath)
                                 .FirstOrDefault(x => x.ToLowerInvariant().Contains(fileName.ToLowerInvariant()));
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            using (var fileStream = File.OpenRead(file))
            {
                var memoryStream = new MemoryStream();
                await fileStream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                return memoryStream;
            }
        }

        public async Task<IEnumerable<ImageInfo>> GetByTagAsync(string tag)
        {
            var fileInfos = await Task.Run(() =>
            {
                var files = Directory.GetFiles(BaseFolderPath)
                                     .Select(x => new Bitmap(x)).ToList();

                var result = files.Select(x => new ImageInfo()
                {
                    UserId = x.GetAuthorId(),
                    Tags = x.GetTags(),
                    Image = (Image)x.Clone()
                }).Where(x => x.Tags.Any(y => y.ToLowerInvariant() == tag.ToLowerInvariant())).ToList();

                files.ForEach(x => x.Dispose());
                return result;
            });

            return fileInfos;
        }
    }
}