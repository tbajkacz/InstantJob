using System.Reflection;
using AutoMapper;
using FluentValidation;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.BuildingBlocks.Application.DomainEvents;
using InstantJob.BuildingBlocks.Application.MediatR;
using InstantJob.BuildingBlocks.Infrastructure.DomainEvents;
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
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkTransactionBehavior<,>))
                .AddValidatorsFromAssemblies(assemblies)
                .AddTransient<IDomainEventsDispatcher, DomainEventsDispatcher>()
                .AddTransient<IDomainEventsAccessor, NHibernateDomainEventsAccessor>();
    }
}
