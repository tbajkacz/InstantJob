using FluentNHibernate.Mapping;
using InstantJob.Core.Common.Types;

namespace InstantJob.Core.NHibernate.Mapping
{
    public class BaseEntityMap<TEntity, TId> : ClassMap<TEntity> where TEntity : BaseEntity<TId>
    {
        public BaseEntityMap()
        {
            Id(x => x.Id);
        }
    }
}
