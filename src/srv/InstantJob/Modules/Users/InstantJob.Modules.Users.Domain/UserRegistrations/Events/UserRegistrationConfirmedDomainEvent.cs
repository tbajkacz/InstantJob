using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Users.Domain.UserRegistrations.Events
{
    public class UserRegistrationConfirmedDomainEvent : IDomainEvent
    {
        public int UserRegistrationId { get; set; }
    }
}
