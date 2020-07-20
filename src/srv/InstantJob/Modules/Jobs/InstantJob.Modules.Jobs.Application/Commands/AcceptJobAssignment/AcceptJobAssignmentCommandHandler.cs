using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Exceptions;
using InstantJob.Modules.Jobs.Application.Interfaces;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Commands.AcceptJobAssignment
{
    public class AcceptJobAssignmentCommandHandler : IRequestHandler<AcceptJobAssignmentCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly ICurrentContractorService currentContractor;

        public AcceptJobAssignmentCommandHandler(IJobRepository jobRepository, ICurrentContractorService currentContractor)
        {
            this.jobRepository = jobRepository;
            this.currentContractor = currentContractor;
        }

        public async Task<Unit> Handle(AcceptJobAssignmentCommand request, CancellationToken cancellationToken)
        {
            var job = await jobRepository.GetByIdAsync(request.JobId);

            job.AcceptJobAssignment(currentContractor.Id);

            return Unit.Value;
        }
    }
}
