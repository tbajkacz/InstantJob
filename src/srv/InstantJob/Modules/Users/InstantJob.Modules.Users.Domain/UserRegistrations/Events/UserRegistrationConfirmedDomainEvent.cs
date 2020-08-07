using System;
using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Users.Domain.UserRegistrations.Events
{
    public class UserRegistrationConfirmedDomainEvent : IDomainEvent
    {
        public Guid UserRegistrationId { get; set; }
    }
}
