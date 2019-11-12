using System.Collections.Generic;

namespace SocialNetwork.Graph.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<UserRelationship> Relationships { get; set; }
    }
}