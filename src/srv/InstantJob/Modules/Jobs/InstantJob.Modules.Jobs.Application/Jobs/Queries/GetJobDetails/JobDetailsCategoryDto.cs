using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Categories;
using System;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetJobDetails
{
    public class JobDetailsCategoryDto : IMapFrom<Category>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
