
using InstantJob.Domain.Categories.Entities;

namespace InstantJob.Persistence.Mapping
{
    internal class CategoryMap : BaseEntityMap<Category, int>
    {
        public CategoryMap()
        {
            Map(x => x.Name)
                .Not.Nullable()
                .Unique();
            Map(x => x.Description);
            HasMany(x => x.JobsInCategory)
                //With Cascade.All Job gets deleted together with categories,
                //Cascade.None causes an exception when trying to delete a category because of foreign key restrictions
                //There is no Cascade.Null option so with Cascade.None it might be required to manually null the Category property in Job when deleting a cateogry
                .Cascade.All()
                .Inverse();
        }
    }
}
