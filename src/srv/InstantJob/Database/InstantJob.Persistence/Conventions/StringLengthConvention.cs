using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace InstantJob.Database.Persistence.Conventions
{
    public class StringLengthConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Length(10000);
        }

        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(inspector => inspector.Type == typeof(string)).Expect(inspector => inspector.Length == 0);
        }
    }
}
