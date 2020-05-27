using InstantJob.Core.Entities;

namespace InstantJob.Core.NHibernate.Mapping
{
    internal class CategoryMap : BaseEntityMap<Category, int>
    {
        public CategoryMap()
        {
            Map(x => x.Name)
                .Not.Nullable();
        }
    }
}
