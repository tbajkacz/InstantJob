using System;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Mandators;

namespace InstantJob.Modules.Jobs.Application.Mandators.Abstractions
{
    public interface IMandatorRepository: IRepository<Mandator, Guid>
    {
        
    }
}
