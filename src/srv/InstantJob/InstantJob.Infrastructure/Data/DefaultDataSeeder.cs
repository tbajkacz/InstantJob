using InstantJob.Core.Common.Interfaces;
using InstantJob.Core.Users.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace InstantJob.Infrastructure.Data
{
    public class DefaultDataSeeder : IDataSeeder
    {
        private readonly IUserManager userManager;

        public DefaultDataSeeder(IUserManager userManager)
        {
            this.userManager = userManager;
        }
        public async Task SeedAsync()
        {
            if (userManager.Users.Any())
            {
                return;
            }

            var rootUser = new User
            {
                Name = "root",
                Surname = "root",
                Email = "root@root.root",
                Type = "root",
            };

            await userManager.CreateAsync(rootUser, "root");
        }
    }
}
