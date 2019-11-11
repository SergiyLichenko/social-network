using System.Collections.Generic;
using System.Data.Entity;
using SocialNetwork.SQL.Repositories.Models;

namespace SocialNetwork.SQL.Repositories
{
    public class SocailNetworkInitializer : DropCreateDatabaseIfModelChanges<SocialNetworkContext>
    {
        protected override void Seed(SocialNetworkContext context)
        {
            context.Users.Add(new User()
            {
                Id = 1,
                FirstName = "Sergiy",
                LastName = "Lichenko",
                City = "Kyiv",
                Country = "Ukraine",
                Email = "sergiy.lichenko@outlook.com",
                Gender = "Male",
                UserName = "SergiyLichenko"
            });
            context.Users.Add(new User()
            {
                Id = 2,
                FirstName = "Lera",
                LastName = "Gaistruk",
                Country = "Ukraine",
                Gender = "Female",
                Email = "leragaistruk@gmail.com",
                UserName = "LeraGaistruk",
                City = "Kyiv"
            });

            base.Seed(context);
        }
    }
}