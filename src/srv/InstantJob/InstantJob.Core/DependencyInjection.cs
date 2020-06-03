using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InstantJob.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            return services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
