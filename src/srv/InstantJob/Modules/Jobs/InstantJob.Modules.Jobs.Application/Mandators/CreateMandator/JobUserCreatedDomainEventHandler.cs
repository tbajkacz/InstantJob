using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Application.Mandators.Abstractions;
using InstantJob.Modules.Jobs.Domain.JobUsers.Events;
using InstantJob.Modules.Jobs.Domain.Mandators;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Mandators.CreateMandator
{
    public class JobUserCreatedDomainEventHandler : INotificationHandler<JobUserCreatedDomainEvent>
    {
        private readonly IMandatorRepository mandators;

        public JobUserCreatedDomainEventHandler(IMandatorRepository mandators)
        {
            this.mandators = mandators;
        }

        public async Task Handle(JobUserCreatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            if (notification.JobUser.Role != Role.Mandator)
            {
                return;
            }

            var mandator = new Mandator(notification.JobUser.Id,
                notification.JobUser);

            await mandators.AddAsync(mandator);
        }
    }
}
