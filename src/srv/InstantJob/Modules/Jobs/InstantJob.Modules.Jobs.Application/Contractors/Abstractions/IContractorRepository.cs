using System;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Contractors;

namespace InstantJob.Modules.Jobs.Application.Contractors.Abstractions
{
    public interface IContractorRepository : IRepository<Contractor, Guid>
    {
        
    }
}
