using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Domain.Constants;
using InstantJob.Modules.Users.Domain.Entities;

namespace InstantJob.Modules.Users.Infrastructure.Data
{
    public class UserSeeder : IDataSeeder
    {
        private readonly IUserManager userManager;
        private readonly IUnitOfWork uow;

        public UserSeeder(IUserManager userManager, IUnitOfWork uow)
        {
            this.userManager = userManager;
            this.uow = uow;
        }
        public async Task SeedAsync()
        {
            uow.BeginTransaction();
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
                Roles = new List<string> { Roles.Administrator, Roles.Mandator, Roles.Contractor },
            };

            await userManager.CreateAsync(rootUser, "root");
        }
    }
}
