using AutoMapper;
using FluentValidation;
using InstantJob.Core.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InstantJob.BuildingBlocks.Application.Extensions
{
    public static class AddBasicServicesForAssembliesExtension
    {
        public static IServiceCollection AddBasicServicesForAssemblies(this IServiceCollection services, IEnumerable<Assembly> assemblies)
            => services.AddAutoMapper(assemblies)
                .AddMediatR(assemblies.ToArray())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>))
                .AddValidatorsFromAssemblies(assemblies);
    }
}
