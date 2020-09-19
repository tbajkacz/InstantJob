using System;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Categories;

namespace InstantJob.Modules.Jobs.Application.Categories.Queries.GetCategories
{
    public class CategoryDto : IMapFrom<Category>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
