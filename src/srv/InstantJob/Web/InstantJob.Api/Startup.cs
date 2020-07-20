using FluentValidation;
using InstantJob.Api.Extensions;
using InstantJob.Api.Middleware;
using InstantJob.Api.Services;
using InstantJob.Core;
using InstantJob.Core.Common.Exceptions;
using InstantJob.Core.Common.Interfaces;
using InstantJob.Infrastructure;
using InstantJob.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InstantJob.Api
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
            services.AddApplication();
            services.AddPersistence(configuration.GetConnectionString("Database"));
            services.AddInfrastructure(configuration);
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();
            services.AddCookieAuthentication(env.IsDevelopment() ? CookieSecurePolicy.None : CookieSecurePolicy.Always);
            services.AddAuthorizationWithPolicies();

            services.AddOpenApiDocument(settings => settings.Title = "Instant Job");

            services.AddControllers()
                .AddUnitOfWorkFinalizerFilter()
                .AddExceptionHandlerFilter();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3(settings => settings.Path = "/swagger");

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
