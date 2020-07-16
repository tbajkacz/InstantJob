using InstantJob.Core.Common.Exceptions;
using InstantJob.Core.Common.Interfaces;
using InstantJob.Domain.Jobs.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Application.Jobs.Commands.AcceptJobAssignment
{
    public class AcceptJobAssignmentCommandHandler : IRequestHandler<AcceptJobAssignmentCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly ICurrentUserService currentUser;

        public AcceptJobAssignmentCommandHandler(IJobRepository jobRepository, ICurrentUserService currentUser)
        {
            this.jobRepository = jobRepository;
            this.currentUser = currentUser;
        }

        public async Task<Unit> Handle(AcceptJobAssignmentCommand request, CancellationToken cancellationToken)
        {
            var job = await jobRepository.GetByIdAsync(request.JobId);

            if (!job.IsOwnedBy(currentUser.UserId))
            {
                throw new EntityAccessException(currentUser.UserId, job.Id, typeof(Job));
            }

            job.AcceptJobAssignment();

            return Unit.Value;
        }
    }
}
