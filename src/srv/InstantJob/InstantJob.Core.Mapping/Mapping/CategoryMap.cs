using InstantJob.Core.Jobs.Models;

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
