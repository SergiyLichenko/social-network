using System.Collections.Generic;
using System.Drawing;

namespace SocialNetwork.MediaFile.Models
{
    public class ImageInfo
    {
        public int UserId { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public Image Image { get; set; }
    }
}