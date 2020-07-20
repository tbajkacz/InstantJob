using FluentNHibernate.Mapping;
using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Database.Persistence.Mapping
{
    public class BaseEntityMap<TEntity, TId> : ClassMap<TEntity> where TEntity : BaseEntity<TId>
    {
        public BaseEntityMap()
        {
            Id(x => x.Id);
        }
    }
}
