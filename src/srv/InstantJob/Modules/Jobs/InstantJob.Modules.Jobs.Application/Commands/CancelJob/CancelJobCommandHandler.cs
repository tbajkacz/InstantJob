using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Exceptions;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Commands.CancelJob
{
    public class CancelJobCommandHandler : IRequestHandler<CancelJobCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly ICurrentMandatorService currentMandator;

        public CancelJobCommandHandler(IJobRepository jobRepository, ICurrentMandatorService currentMandator)
        {
            this.jobRepository = jobRepository;
            this.currentMandator = currentMandator;
        }

        public async Task<Unit> Handle(CancelJobCommand request, CancellationToken cancellationToken)
        {
            var job = await jobRepository.GetByIdAsync(request.JobId);

            job.CancelJobOffer(currentMandator.Id);

            return Unit.Value;
        }
    }
}
