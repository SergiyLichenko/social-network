using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SocialNetwork.MediaFile.Infrastructure
{
    public static class ImageExtensions
    {
        public static int GetAuthorId(this Image image)
        {
            if (!image.PropertyIdList.Contains(40093))
                return -1;

            var value = image.GetPropertyItem(40093).Value;
            var authorIdString = Encoding.Unicode.GetString(value).Split(';').First();

            return Convert.ToInt32(authorIdString);
        }

        public static IEnumerable<string> GetTags(this Image image)
        {
            if (!image.PropertyIdList.Contains(40094))
                return new List<string>();

            var value = image.GetPropertyItem(40094).Value;
            return Encoding.Unicode.GetString(value).Split(';')
                           .Select(x => x.Replace("\0", ""));
        }
    }
}