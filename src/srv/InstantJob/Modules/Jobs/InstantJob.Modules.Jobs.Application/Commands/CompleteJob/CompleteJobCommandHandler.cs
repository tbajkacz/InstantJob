using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Exceptions;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Commands.CompleteJob
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
