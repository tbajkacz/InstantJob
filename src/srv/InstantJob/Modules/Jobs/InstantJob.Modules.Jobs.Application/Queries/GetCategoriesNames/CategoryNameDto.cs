using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Categories;

namespace InstantJob.Modules.Jobs.Application.Queries.GetCategoriesNames
{
    public class CategoryNameDto : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
