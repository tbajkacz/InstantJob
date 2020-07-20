using InstantJob.Modules.Users.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Infrastructure.Identity;
using InstantJob.Modules.Users.Infrastructure.Security;
using Microsoft.Extensions.Configuration;

namespace InstantJob.Modules.Users.Infrastructure.Configuration
{
    public static class AddUsersModuleExtension
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
            => services.AddScoped<IUserRepository, NHibernateUserRepository>()
                       .AddSingleton<IHashService, HashService>()
                       .Configure<HashOptions>(configuration.GetSection("Hash"))
                       .AddScoped<IUserManager, UserManager>()
                       .AddScoped<IDataSeeder, UserSeeder>();
    }
}
