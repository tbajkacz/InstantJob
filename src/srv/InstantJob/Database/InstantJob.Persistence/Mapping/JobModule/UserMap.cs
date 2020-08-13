using System;
using InstantJob.Modules.Jobs.Domain.JobUsers;

namespace InstantJob.Database.Persistence.Mapping.JobModule
{
    internal class UserMap : BaseEntityMap<JobUser, Guid>
    {
        public UserMap()
        {
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.Email);
        }
    }
}
