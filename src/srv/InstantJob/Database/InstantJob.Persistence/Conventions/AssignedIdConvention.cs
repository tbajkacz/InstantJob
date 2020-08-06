using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace InstantJob.Database.Persistence.Conventions
{
    public class AssignedIdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            if (instance.Type.Name.Contains("int", StringComparison.InvariantCultureIgnoreCase))
            {
                instance.GeneratedBy.Assigned();
            }
        }
    }
}
