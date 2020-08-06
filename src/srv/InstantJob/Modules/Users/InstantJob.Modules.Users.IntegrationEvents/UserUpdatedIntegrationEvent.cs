using InstantJob.BuildingBlocks.Application.EventBus;

namespace InstantJob.Modules.Users.IntegrationEvents
{
    public class UserUpdatedIntegrationEvent : IIntegrationEvent
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public UserUpdatedIntegrationEvent(int userId, string name, string surname)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
        }
    }
}
