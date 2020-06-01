using InstantJob.Api.Extensions;
using InstantJob.Api.Middleware;
using InstantJob.Api.Services;
using InstantJob.Core.Common.Interfaces;
using InstantJob.Core.NHibernate;
using InstantJob.Infrastructure;
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
            services.AddHttpContextAccessor();
            services.AddPersistence(configuration.GetConnectionString("Database"));
            services.AddInfrastructure(configuration);
            services.AddCookieAuthentication(env.IsDevelopment() ? CookieSecurePolicy.None : CookieSecurePolicy.Always);
            services.AddAuthorizationWithPolicies();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddControllers().AddUnitOfWorkFinalizerFilter();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
