using InstantJob.Core.Common.Mappings;
using InstantJob.Core.Users.Entities;

namespace InstantJob.Core.Jobs.Queries.GetJobDetails
{
    public class JobDetailsUserDto : IMapFrom<User>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
