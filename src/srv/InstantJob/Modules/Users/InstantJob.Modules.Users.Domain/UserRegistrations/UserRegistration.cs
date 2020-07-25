using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Domain.UserRegistrations.Events;
using InstantJob.Modules.Users.Domain.Users;

namespace InstantJob.Modules.Users.Domain.UserRegistrations
{
    public class UserRegistration : BaseEntity<int>
    {
        public virtual string Name { get; protected set; }

        public virtual string Surname { get; protected set; }

        public virtual string Email { get; protected set; }

        public virtual string PasswordHash { get; protected set; }

        public virtual Role Role { get; set; }

        public virtual bool Confirmed { get; protected set; }

        protected UserRegistration()
        {
            
        }

        public UserRegistration(string name, string surname, string email, string passwordHash, Role role)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }

        public virtual void Confirm()
        {
            Confirmed = true;
            AddDomainEvent(new UserRegistrationConfirmedDomainEvent { UserRegistrationId = Id});
        }
    }
}
