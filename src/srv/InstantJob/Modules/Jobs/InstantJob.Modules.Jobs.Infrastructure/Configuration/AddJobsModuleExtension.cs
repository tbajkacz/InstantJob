using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstantJob.Modules.Jobs.Infrastructure.Configuration
{
    public static class AddJobsModuleExtension
    {
        public static IServiceCollection AddJobsModule(this IServiceCollection services, IConfiguration configuration)
            => services.AddScoped<IJobRepository, NHibernateJobRepository>()
                       .AddScoped<ICategoryRepository, NHibernateCategoryRepository>();
    }
}
