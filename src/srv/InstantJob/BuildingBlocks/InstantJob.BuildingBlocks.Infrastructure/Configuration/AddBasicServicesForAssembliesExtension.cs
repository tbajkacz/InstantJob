using System.Reflection;
using AutoMapper;
using FluentValidation;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.BuildingBlocks.Application.MediatR;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace InstantJob.BuildingBlocks.Infrastructure.Configuration
{
    public static class AddBasicServicesForAssembliesExtension
    {
        public static IServiceCollection AddBasicServicesForAssemblies(this IServiceCollection services, params Assembly[] assemblies)
            => services.AddAutoMapper(c => c.AddProfile(new MappingProfile(assemblies)))
                .AddMediatR(assemblies)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>))
                .AddValidatorsFromAssemblies(assemblies);
    }
}
