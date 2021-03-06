﻿using System.Collections.Generic;

namespace SocialNetwork.MediaFile.Models
{
    public class ImageInfo
    {
        public int UserId { get; set; }
        public string Src { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}