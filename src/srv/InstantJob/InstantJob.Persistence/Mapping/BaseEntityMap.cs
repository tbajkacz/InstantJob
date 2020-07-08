using FluentNHibernate.Mapping;
using InstantJob.Domain.Common;

namespace InstantJob.Persistence.Mapping
{
    public class BaseEntityMap<TEntity, TId> : ClassMap<TEntity> where TEntity : BaseEntity<TId>
    {
        public BaseEntityMap()
        {
            Id(x => x.Id);
        }
    }
}
