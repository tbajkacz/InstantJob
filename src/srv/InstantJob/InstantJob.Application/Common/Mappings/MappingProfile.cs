using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace InstantJob.Core.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMapsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void CreateMapsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var methodInfo = type.GetMethod("CreateMap") ??
                    type.GetInterfaces()
                    .SingleOrDefault(t => t.GetGenericTypeDefinition() == typeof(IMapFrom<>))
                    .GetMethod("CreateMap");

                methodInfo.Invoke(Activator.CreateInstance(type), new object[] { this });
            }
        }
    }
}
