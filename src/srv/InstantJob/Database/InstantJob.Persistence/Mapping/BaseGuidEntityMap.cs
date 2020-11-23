using FluentNHibernate.Mapping;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Database.Persistence.CustomTypes;
using System;

namespace InstantJob.Database.Persistence.Mapping
{
    public class BaseGuidEntityMap<TEntity> : ClassMap<TEntity> where TEntity : BaseEntity<Guid>
    {
        public BaseGuidEntityMap()
        {
            Id(x => x.Id)
                .CustomType<GuidType>();
        }
    }
}
