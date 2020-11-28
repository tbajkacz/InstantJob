using System;
using System.IO;
using System.Reflection;
using InstantJob.BuildingBlocks.Application.DomainEvents;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.BuildingBlocks.Infrastructure.Configuration;
using InstantJob.BuildingBlocks.Infrastructure.DomainEvents;
using InstantJob.BuildingBlocks.Infrastructure.Seeding;
using InstantJob.Database.Persistence.Configuration;
using InstantJob.Modules.Jobs.Application.Categories.Commands.AddCategory;
using InstantJob.Modules.Jobs.Application.Contractors.Abstractions;
using InstantJob.Modules.Jobs.Application.JobUsers.CreateJobUser;
using InstantJob.Modules.Jobs.Application.JobUsers.UpdateJobUser;
using InstantJob.Modules.Jobs.Application.Mandators.Abstractions;
using InstantJob.Modules.Jobs.Infrastructure.Configuration;
using InstantJob.Modules.Users.Application.Users.Abstractions;
using InstantJob.Modules.Users.Application.Users.Commands.CreateUser;
using InstantJob.Modules.Users.Infrastructure.Configuration;
using InstantJob.Modules.Users.IntegrationEvents;
using InstantJob.Web.Api.Extensions;
using InstantJob.Web.Api.Middleware;
using InstantJob.Web.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace InstantJob.Web.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBasicServicesForAssemblies(typeof(AddCategoryCommand).Assembly, typeof(CreateUserCommand).Assembly);
            services.AddInMemoryEventBus()
                .RegisterIntegrationEventHandlers(cfg =>
                {
                    cfg.AddHandler<UserCreatedIntegrationEventHandler>(UserCreatedIntegrationEvent.GetKey());
                    cfg.AddHandler<UserUpdatedIntegrationEventHandler>(UserUpdatedIntegrationEvent.GetKey());
                });

            services.AddPersistence(configuration.GetConnectionString("Database"));
            services.AddUsersModule(configuration);
            services.AddJobsModule();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ICurrentMandatorService, CurrentMandatorService>();
            services.AddScoped<ICurrentContractorService, CurrentContractorService>();
            services.AddHttpContextAccessor();
            services.AddCookieAuthentication(env.IsDevelopment() ? CookieSecurePolicy.None : CookieSecurePolicy.Always);
            services.AddAuthorizationWithPolicies();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Instant Job", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
            });

            services.AddControllers()
                .AddExceptionHandlerFilter();

            services.AddHostedService<SeedingService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Instant Job v1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
