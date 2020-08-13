using System;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Categories;

namespace InstantJob.Modules.Jobs.Application.Categories.Abstractions
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
    }
}
