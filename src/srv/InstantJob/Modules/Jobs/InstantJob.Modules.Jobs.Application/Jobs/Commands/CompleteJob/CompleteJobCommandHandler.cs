using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using InstantJob.Modules.Jobs.Application.Mandators.Abstractions;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.CompleteJob
{
    public class CompleteJobCommandHandler : IRequestHandler<CompleteJobCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly ICurrentMandatorService currentMandator;

        public CompleteJobCommandHandler(IJobRepository jobRepository, ICurrentMandatorService currentMandator)
        {
            this.jobRepository = jobRepository;
            this.currentMandator = currentMandator;
        }

        public async Task<Unit> Handle(CompleteJobCommand request, CancellationToken cancellationToken)
        {
            var job = await jobRepository.GetByIdAsync(request.JobId);

            job.CompleteJob(currentMandator.Id);

            await jobRepository.UpdateAsync(job);

            return Unit.Value;
        }
    }
}
