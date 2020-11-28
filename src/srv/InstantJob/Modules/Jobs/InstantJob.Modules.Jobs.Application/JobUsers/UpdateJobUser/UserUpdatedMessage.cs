using System;

namespace InstantJob.Modules.Jobs.Application.JobUsers.UpdateJobUser
{
    public class UserUpdatedMessage
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
