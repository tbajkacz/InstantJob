using System;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Categories;

namespace InstantJob.Modules.Jobs.Application.Interfaces
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
    }
}
