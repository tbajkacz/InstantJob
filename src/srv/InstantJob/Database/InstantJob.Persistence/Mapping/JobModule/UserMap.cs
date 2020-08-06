using InstantJob.Modules.Jobs.Domain.Users;

namespace InstantJob.Database.Persistence.Mapping.JobModule
{
    internal class UserMap : BaseEntityMap<JobUser, int>
    {
        public UserMap()
        {
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.Email);
        }
    }
}
