using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace InstantJob.Database.Persistence.Conventions
{
    public class AssignedIdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.Assigned();
        }
    }
}
