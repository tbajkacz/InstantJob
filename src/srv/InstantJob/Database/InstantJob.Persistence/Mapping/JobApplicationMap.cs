using InstantJob.Database.Persistence.CustomTypes;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Database.Persistence.Mapping
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
