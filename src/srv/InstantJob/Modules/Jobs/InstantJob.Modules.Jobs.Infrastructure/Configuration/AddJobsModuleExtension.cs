using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace InstantJob.Modules.Jobs.Infrastructure.Configuration
{
    public static class AddJobsModuleExtension
    {
        public static IServiceCollection AddJobsModule(this IServiceCollection services)
            => services.AddScoped<IJobRepository, NHibernateJobRepository>()
                       .AddScoped<ICategoryRepository, NHibernateCategoryRepository>()
                       .AddScoped<IContractorRepository, NHibernateContractorRepository>()
                       .AddScoped<IMandatorRepository, NHibernateMandatorRepository>();
    }
}
