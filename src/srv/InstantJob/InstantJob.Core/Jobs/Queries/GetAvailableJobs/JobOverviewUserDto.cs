using InstantJob.Core.Common.Mappings;
using InstantJob.Core.Users.Entities;

namespace InstantJob.Core.Jobs.Queries.GetAvailableJobs
{
    public class JobOverviewUserDto : IMapFrom<User>
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
