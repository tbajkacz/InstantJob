using System;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.JobUsers.Events;

namespace InstantJob.Modules.Jobs.Domain.JobUsers
{
    public class JobUser : BaseEntity<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual string Surname { get; protected set; }

        public virtual string Email { get; protected set; }

        public virtual Role Role { get; protected set; }

        protected JobUser()
        {
        }

        public JobUser(Guid id, string name, string surname, string email, Role role)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Role = role;

            this.AddDomainEvent(new JobUserCreatedDomainEvent(this));
        }

        public virtual void UpdateInformation(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
