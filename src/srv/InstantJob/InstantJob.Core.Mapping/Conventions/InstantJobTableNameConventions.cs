using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace InstantJob.Core.NHibernate.Conventions
{
    public class InstantJobTableNameConventions : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table("IJ_" + instance.TableName);
        }
    }
}
