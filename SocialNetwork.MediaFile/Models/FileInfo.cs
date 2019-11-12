using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace SocialNetwork.MediaFile.Models
{
    public class ImageInfo
    {
        public int UserId { get; set; }
        public string Src { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public Stream Image { get; set; }
    }
}