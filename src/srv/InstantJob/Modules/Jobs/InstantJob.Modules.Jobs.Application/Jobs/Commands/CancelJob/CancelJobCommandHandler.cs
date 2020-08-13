using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using InstantJob.Modules.Jobs.Application.Mandators.Abstractions;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.CancelJob
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
