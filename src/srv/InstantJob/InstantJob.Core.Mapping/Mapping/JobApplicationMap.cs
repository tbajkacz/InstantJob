using InstantJob.Domain.Jobs.Entities;

namespace InstantJob.Persistence.Mapping
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
