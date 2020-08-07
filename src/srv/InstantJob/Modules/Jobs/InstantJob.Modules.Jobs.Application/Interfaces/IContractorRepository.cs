using System;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Contractors;

namespace InstantJob.Modules.Jobs.Application.Interfaces
{
    public interface IContractorRepository : IRepository<Contractor, Guid>
    {
        
    }
}
