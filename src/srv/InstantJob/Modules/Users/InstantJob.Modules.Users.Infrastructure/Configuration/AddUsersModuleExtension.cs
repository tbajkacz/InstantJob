using InstantJob.Modules.Users.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantJob.Modules.Users.Infrastructure.Configuration
{
    public static class AddUsersModuleExtension
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services)
            => services.AddScoped<IUserRepository, NHibernateUserRepository>()
                       .AddSingleton<IHashService, HashService>()
                       .Configure<HashOptions>(configuration.GetSection("Hash"))
                       .AddScoped<IUserManager, UserManager>()
                       .AddScoped<IDataSeeder, UserSeeder>()
                       .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
