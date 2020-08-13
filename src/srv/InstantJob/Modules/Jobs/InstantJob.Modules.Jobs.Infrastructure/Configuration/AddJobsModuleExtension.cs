using InstantJob.Modules.Jobs.Application.Categories.Abstractions;
using InstantJob.Modules.Jobs.Application.Contractors.Abstractions;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using InstantJob.Modules.Jobs.Application.JobUsers.Abstractions;
using InstantJob.Modules.Jobs.Application.Mandators.Abstractions;
using InstantJob.Modules.Jobs.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace InstantJob.Modules.Jobs.Infrastructure.Configuration
{
    public static class AddJobsModuleExtension
    {
        public static IServiceCollection AddJobsModule(this IServiceCollection services)
            => services.AddScoped<IJobRepository, NHibernateJobRepository>()
                       .AddScoped<ICategoryRepository, NHibernateCategoryRepository>()
                       .AddScoped<IUserRepository, NHibernateUserRepository>()
                       .AddScoped<IMandatorRepository, NHibernateMandatorRepository>()
                       .AddScoped<IContractorRepository, NHibernateContractorRepository>();
    }
}
