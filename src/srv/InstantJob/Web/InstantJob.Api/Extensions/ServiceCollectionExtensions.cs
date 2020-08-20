using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Exceptions;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Application.Users.Queries.GetUserRolesQuery;
using InstantJob.Web.Api.Constants;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace InstantJob.Web.Api.Extensions
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
                            var mediator = context.HttpContext.RequestServices.GetRequiredService<IMediator>();
                            try
                            {
                                Role role = await mediator.Send(new GetUserRoleQuery { Id = GetId(context.Principal) });

                                var incomingRole = context.Principal.Claims
                                    ?.SingleOrDefault(c =>
                                        c.Type == ClaimTypes.Role)?.Value;

                                if (incomingRole != role.Name)
                                {
                                    await context.HttpContext.SignOutAsync();
                                    context.RejectPrincipal();
                                }
                            }
                            catch (Exception e) when (e is EntityNotFoundException || e is InvalidUserSessionException || e is ValidationFailedException)
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

        private static Guid GetId(ClaimsPrincipal principal)
        {
            if (!Guid.TryParse(principal.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out Guid id))
            {
                throw new InvalidUserSessionException();
            }
            return id;
        }

        public static IServiceCollection AddAuthorizationWithPolicies(this IServiceCollection services)
            => services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy(Policies.Administrator, p => p.RequireRole(Role.Administrator.Name));
                cfg.AddPolicy(Policies.Contractor,
                              p => p.RequireAssertion(ctx => ctx.User.IsInRole(Role.Contractor.Name) ||
                                                             ctx.User.IsInRole(Role.Administrator.Name)
                ));
                cfg.AddPolicy(Policies.Mandator,
                              p => p.RequireAssertion(ctx => ctx.User.IsInRole(Role.Mandator.Name) ||
                                                             ctx.User.IsInRole(Role.Administrator.Name)
                ));
            });
    }
}
