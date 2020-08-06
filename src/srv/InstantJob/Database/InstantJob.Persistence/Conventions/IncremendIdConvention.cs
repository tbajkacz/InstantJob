using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace InstantJob.Database.Persistence.Conventions
{
    [Obsolete("Unused, ids are currently assigned manually")]
    public class IncrementIdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            if (instance.Type.Name.Contains("int", StringComparison.InvariantCultureIgnoreCase))
            {
                instance.GeneratedBy.Increment();
            }
        }
    }
}
