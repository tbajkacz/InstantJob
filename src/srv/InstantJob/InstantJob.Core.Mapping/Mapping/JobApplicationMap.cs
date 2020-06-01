using InstantJob.Core.Jobs.Entities;

namespace InstantJob.Core.NHibernate.Mapping
{
    internal class JobApplicationMap : BaseEntityMap<JobApplication, int>
    {
        public JobApplicationMap()
        {
            Map(x => x.MandateeId)
                .Not.Nullable();
            Map(x => x.ApplicationDate)
                .Not.Nullable();
        }
    }
}
