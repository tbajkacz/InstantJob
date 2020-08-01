using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.EventBus;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Mandators;
using InstantJob.Modules.Users.IntegrationEvents;

namespace InstantJob.Modules.Jobs.Application.CreateMandator
{
    public class MandatorCreatedIntegrationEventHandler : IIntegrationEventHandler<MandatorCreatedIntegrationEvent>
    {
        private readonly IMandatorRepository mandators;

        public MandatorCreatedIntegrationEventHandler(IMandatorRepository mandators)
        {
            this.mandators = mandators;
        }


        public async Task Handle(MandatorCreatedIntegrationEvent notification,
            CancellationToken cancellationToken)
        {
            var mandator = new Mandator(notification.UserId, notification.Name, notification.Surname, notification.Email);

            await mandators.AddAsync(mandator);
        }
    }
}
