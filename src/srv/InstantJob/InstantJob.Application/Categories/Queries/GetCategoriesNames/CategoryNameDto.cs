using InstantJob.Core.Common.Mappings;
using InstantJob.Domain.Categories.Entities;

namespace InstantJob.Core.Categories.Queries.GetCategoriesNames
{
    public class CategoryNameDto : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
