using InstantJob.Core.Jobs.Entities;

namespace InstantJob.Core.NHibernate.Mapping
{
    internal class JobApplicationMap : BaseEntityMap<JobApplication, int>
    {
        public JobApplicationMap()
        {
            References(x => x.Contractor)
                .Not.Nullable();
            Map(x => x.ApplicationDate)
                .Not.Nullable();
        }
    }
}
