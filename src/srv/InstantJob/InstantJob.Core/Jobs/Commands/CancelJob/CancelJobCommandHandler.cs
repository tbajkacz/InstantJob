using InstantJob.Core.Common.Exceptions;
using InstantJob.Core.Common.Interfaces;
using InstantJob.Core.Jobs.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Core.Jobs.Commands.CancelJob
{
    public class CancelJobCommandHandler : IRequestHandler<CancelJobCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly ICurrentUserService currentUser;

        public CancelJobCommandHandler(IJobRepository jobRepository, ICurrentUserService currentUser)
        {
            this.jobRepository = jobRepository;
            this.currentUser = currentUser;
        }

        public async Task<Unit> Handle(CancelJobCommand request, CancellationToken cancellationToken)
        {
            var job = await jobRepository.GetByIdAsync(request.JobId);

            if (!job.WasPostedBy(currentUser.UserId))
            {
                throw new EntityAccessException(currentUser.UserId, job.Id, typeof(Job));
            }

            job.CancelJobOffer();

            return Unit.Value;
        }
    }
}
