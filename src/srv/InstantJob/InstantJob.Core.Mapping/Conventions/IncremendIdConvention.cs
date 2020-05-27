using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Linq;

namespace InstantJob.Core.NHibernate.Conventions
{
    public class IncrementIdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            if (!instance.Type.Name.Contains("string", StringComparison.InvariantCultureIgnoreCase))
            {
                instance.GeneratedBy.Increment();
            }
        }
    }
}
