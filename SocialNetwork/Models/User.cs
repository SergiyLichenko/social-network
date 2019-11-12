using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }

        public IEnumerable<ImageInfo> Images { get; set; }
    }
}