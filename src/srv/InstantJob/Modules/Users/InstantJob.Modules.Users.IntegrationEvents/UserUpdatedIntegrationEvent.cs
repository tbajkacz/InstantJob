using System;
using InstantJob.BuildingBlocks.Application.EventBus;

namespace InstantJob.Modules.Users.IntegrationEvents
{
    public class UserUpdatedIntegrationEvent : IIntegrationEvent
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public UserUpdatedIntegrationEvent(Guid userId, string name, string surname)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
        }

        public static string GetKey()
        {
            return "Modules.Users.IntegrationEvents.UserUpdatedDomainEventHandler";
        }
    }
}
