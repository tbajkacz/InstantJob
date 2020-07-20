using AutoMapper;

namespace InstantJob.BuildingBlocks.Application.Automapper
{
    public interface IMapFrom<T>
    {
        void CreateMap(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
