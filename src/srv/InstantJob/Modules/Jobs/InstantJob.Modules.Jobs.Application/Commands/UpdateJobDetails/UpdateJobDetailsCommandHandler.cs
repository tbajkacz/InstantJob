using InstantJob.Core.Common.Exceptions;
using InstantJob.Core.Common.Interfaces;
using InstantJob.Domain.Common;
using InstantJob.Domain.Jobs.Constants;
using InstantJob.Domain.Jobs.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Core.Jobs.Commands.UpdateJobDetails
{
    public class UpdateJobDetailsCommandHandler : IRequestHandler<UpdateJobDetailsCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly ICurrentUserService currentUser;

        public UpdateJobDetailsCommandHandler(IJobRepository jobRepository, ICurrentUserService currentUser)
        {
            this.jobRepository = jobRepository;
            this.currentUser = currentUser;
        }

        public async Task<Unit> Handle(UpdateJobDetailsCommand request, CancellationToken cancellationToken)
        {
            var job = await jobRepository.GetByIdAsync(request.JobId);

            if (!job.IsOwnedBy(currentUser.UserId))
            {
                throw new EntityAccessException(currentUser.UserId, job.Id, typeof(Job));
            }

            job.UpdateJobDetails(
                request.Title,
                request.Description,
                request.Price,
                request.Deadline,
                Enumeration.FromInt<Difficulty>(request.DifficultyId)
                );
            await jobRepository.UpdateAsync(job);
            return Unit.Value;
        }
    }
}
