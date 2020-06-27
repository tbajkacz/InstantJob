using InstantJob.Core.Categories.Entities;
using InstantJob.Core.Common.Mappings;

namespace InstantJob.Core.Categories.Queries.GetCategoriesNames
{
    public class CategoryNameDto : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
