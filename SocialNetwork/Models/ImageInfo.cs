using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public class ImageInfo
    {
        public string Src { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}