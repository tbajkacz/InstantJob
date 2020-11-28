using InstantJob.BuildingBlocks.Domain;
using System;

namespace InstantJob.Modules.Jobs.Application.JobUsers.CreateJobUser
{
    public class UserCreatedMessage
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }
    }
}
