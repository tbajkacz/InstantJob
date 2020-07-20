using InstantJob.Domain.Jobs.Constants;
using InstantJob.Domain.Jobs.Entities;
using InstantJob.Persistence.CustomTypes;

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
            Map(x => x.Status)
                .CustomType<EnumerationType<ApplicationStatus>>();
        }
    }
}
