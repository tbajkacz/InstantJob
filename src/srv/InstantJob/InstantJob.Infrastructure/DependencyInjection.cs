using InstantJob.Core.Common.Interfaces;
using InstantJob.Infrastructure.Data;
using InstantJob.Infrastructure.Identity;
using InstantJob.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstantJob.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            => services.AddScoped<IUnitOfWork, NHibernateUnitOfWork>()
                       .AddScoped<IUserRepository, NHibernateUserRepository>()
                       .AddSingleton<IHashService, HashService>()
                       .Configure<HashOptions>(configuration.GetSection("Hash"))
                       .AddScoped<IUserManager, UserManager>()
                       .AddScoped<IDataSeeder, DefaultDataSeeder>();
    }
}
