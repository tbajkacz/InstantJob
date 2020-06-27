using InstantJob.Core.Common.Interfaces;
using InstantJob.Domain.Users.Constants;
using InstantJob.Domain.Users.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace InstantJob.Infrastructure.Data
{
    public class DefaultDataSeeder : IDataSeeder
    {
        private readonly IUserManager userManager;
        private readonly IUnitOfWork uow;

        public DefaultDataSeeder(IUserManager userManager, IUnitOfWork uow)
        {
            this.userManager = userManager;
            this.uow = uow;
        }
        public async Task SeedAsync()
        {
            await SeedUsers();
            await uow.CommitAsync();
        }

        private async Task SeedUsers()
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
                Type = Roles.Administrator,
            };

            await userManager.CreateAsync(rootUser, "root");
        }
    }
}
