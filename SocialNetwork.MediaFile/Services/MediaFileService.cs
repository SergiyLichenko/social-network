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
                var filePaths = Directory.GetFiles(BaseFolderPath).ToList();
                var bitmaps = filePaths.Select(x => new Bitmap(x)).ToList();

                var result = bitmaps.Select((x, index) => new ImageInfo()
                {
                    UserId = x.GetAuthorId(),
                    Tags = x.GetTags(),
                    Src = filePaths[index]
                }).Where(x => x.UserId == userId).ToList();

                bitmaps.ForEach(x => x.Dispose());
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
                var filePaths = Directory.GetFiles(BaseFolderPath)
                                     .OrderByDescending(x => new FileInfo(x).CreationTime)
                                     .ToList();

                var bitmaps = filePaths.Select(x => new Bitmap(x)).ToList();
                var result = bitmaps.Select((x, index) => new ImageInfo()
                {
                    UserId = x.GetAuthorId(),
                    Tags = x.GetTags(),
                    Src = filePaths[index]
                }).Where(x => x.Tags.Any(y => y.ToLowerInvariant() == tag.ToLowerInvariant())).ToList();

                bitmaps.ForEach(x => x.Dispose());
                return result;
            });

            return fileInfos;
        }

        public async Task<IEnumerable<ImageInfo>> QueryImagesAsync(Query query)
        {
            var fileInfos = await Task.Run(() =>
            {
                var filePaths = Directory.GetFiles(BaseFolderPath)
                                         .OrderByDescending(x => new FileInfo(x).CreationTime)
                                         .Skip(query.Offset).Take(query.Count).ToList();

                var bitmaps = filePaths.Select(x => new Bitmap(x)).ToList();
                var result = bitmaps.Select((x, index) => new ImageInfo()
                {
                    UserId = x.GetAuthorId(),
                    Tags = x.GetTags(),
                    Src = filePaths[index]
                }).ToList();

                bitmaps.ForEach(x => x.Dispose());
                return result;
            });

            return fileInfos;
        }
    }
}