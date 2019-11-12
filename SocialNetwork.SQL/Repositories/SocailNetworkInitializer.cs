using System.Data.Entity;
using SocialNetwork.SQL.Infrastructure;

namespace SocialNetwork.SQL.Repositories
{
    public class SocailNetworkInitializer : DropCreateDatabaseAlways<SocialNetworkContext>
    {
        protected override void Seed(SocialNetworkContext context)
        {
            var users = FileReader.GetUsersAsync()
                                  .GetAwaiter()
                                  .GetResult();

            foreach (var user in users)
                context.Users.Add(user);

            base.Seed(context);
        }
    }
}