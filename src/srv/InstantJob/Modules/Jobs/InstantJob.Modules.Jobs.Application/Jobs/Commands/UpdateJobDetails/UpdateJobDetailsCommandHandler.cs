using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using InstantJob.Modules.Jobs.Application.Mandators.Abstractions;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.UpdateJobDetails
{
    public class UpdateJobDetailsCommandHandler : IRequestHandler<UpdateJobDetailsCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly ICurrentMandatorService currentMandator;

        public UpdateJobDetailsCommandHandler(IJobRepository jobRepository, ICurrentMandatorService currentMandator)
        {
            this.jobRepository = jobRepository;
            this.currentMandator = currentMandator;
        }

        public async Task<Unit> Handle(UpdateJobDetailsCommand request, CancellationToken cancellationToken)
        {
            var job = await jobRepository.GetByIdAsync(request.JobId);

            job.UpdateJobDetails(
                request.Title,
                request.Description,
                request.Price,
                request.Deadline,
                Enumeration.FromInt<Difficulty>(request.DifficultyId),
                currentMandator.Id
                );
            await jobRepository.UpdateAsync(job);
            return Unit.Value;
        }
    }
}
