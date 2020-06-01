using InstantJob.Api.Constants;
using InstantJob.Core.Common.Exceptions;
using InstantJob.Core.Common.Interfaces;
using InstantJob.Core.Users.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InstantJob.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static AuthenticationBuilder AddCookieAuthentication(this IServiceCollection services, CookieSecurePolicy cookieSecurePolicy)
            => services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(cfg =>
                {
                    cfg.Cookie.SecurePolicy = cookieSecurePolicy;

                    cfg.Events = new CookieAuthenticationEvents
                    {
                        OnValidatePrincipal = async context =>
                        {
                            var currentUser = context.HttpContext.RequestServices.GetRequiredService<ICurrentUserService>();
                            try
                            {
                                var claimRoles = context.Principal.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Role).Value;
                                if (currentUser.Type != claimRoles)
                                {
                                    await context.HttpContext.SignOutAsync();
                                    context.RejectPrincipal();
                                }
                            }
                            catch (Exception e) when (e is FormatException || e is EntityNotFoundException)
                            {
                                context.RejectPrincipal();
                            }
                        },
                        OnRedirectToAccessDenied = context =>
                        {
                            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                            return Task.CompletedTask;
                        },
                        OnRedirectToLogin = context =>
                        {
                            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            return Task.CompletedTask;
                        },
                    };
                });

        public static IServiceCollection AddAuthorizationWithPolicies(this IServiceCollection services)
            => services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy(Policies.Administrator, p => p.RequireRole(Roles.Administrator));
                cfg.AddPolicy(Policies.Mandatee,
                              p => p.RequireAssertion(ctx => ctx.User.IsInRole(Roles.Mandatee) ||
                                                             ctx.User.IsInRole(Roles.Administrator)
                ));
                cfg.AddPolicy(Policies.Mandator,
                              p => p.RequireAssertion(ctx => ctx.User.IsInRole(Roles.Mandatee) ||
                                                             ctx.User.IsInRole(Roles.Administrator)
                ));
            });
    }
}
