using System.Data.Entity;
using SocialNetwork.SQL.Models;

namespace SocialNetwork.SQL.Repositories
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext() : base("SocialNetwork")
        {
            Database.SetInitializer(new SocailNetworkInitializer());
        }

        public IDbSet<User> Users { get; set; }
    }
}