using System;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Mandators;

namespace InstantJob.Modules.Jobs.Application.Interfaces
{
    public interface IMandatorRepository: IRepository<Mandator, Guid>
    {
        
    }
}
