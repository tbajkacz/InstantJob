using InstantJob.Core.Interfaces;
using InstantJob.Infrastructure.Data;
using InstantJob.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace InstantJob.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, NHibernateUnitOfWork>()
                       .AddScoped<IUserRepository, NHibernateUserRepository>()
                       .AddSingleton<IHashService, HashService>();
    }
}
