using AutoMapper;

namespace InstantJob.Core.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void CreateMap(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
