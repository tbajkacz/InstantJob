using System.Globalization;
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
        {
            // ensures that the default messages are in english
            ValidatorOptions.Global.LanguageManager.Culture = CultureInfo.InvariantCulture;

            services.AddAutoMapper(c => c.AddProfile(new MappingProfile(assemblies)))
                .AddMediatR(assemblies)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkTransactionBehavior<,>))
                .AddValidatorsFromAssemblies(assemblies)
                .AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>()
                .AddScoped<IDomainEventsAccessor, NHibernateDomainEventsAccessor>()
                .Decorate(typeof(INotificationHandler<>), typeof(NotificationHandlerDomainEventsDispatcherDecorator<>));
            //.Scan(selector =>
            //{
            //    selector.FromAssemblies(assemblies)
            //        .AddClasses(filter => filter.AssignableTo(typeof(IIntegrationEventHandler<>)))
            //        .AsSelf()
            //        .WithTransientLifetime();
            //});

            return services;
        }
    }
}
