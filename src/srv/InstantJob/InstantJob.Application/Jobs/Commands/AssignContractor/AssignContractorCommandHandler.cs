using InstantJob.Core.Common.Exceptions;
using InstantJob.Core.Common.Interfaces;
using InstantJob.Domain.Jobs.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Core.Jobs.Commands.AssignContractor
{
    public class AssignContractorCommandHandler : IRequestHandler<AssignContractorCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly IUserRepository userRepository;
        private readonly ICurrentUserService currentUser;

        public AssignContractorCommandHandler(
            IJobRepository jobRepository,
            IUserRepository userRepository,
            ICurrentUserService currentUser)
        {
            this.jobRepository = jobRepository;
            this.userRepository = userRepository;
            this.currentUser = currentUser;
        }

        public async Task<Unit> Handle(AssignContractorCommand request, CancellationToken cancellationToken)
        {
            var job = await jobRepository.GetByIdAsync(request.JobId);

            if (!job.IsOwnedBy(currentUser.UserId))
            {
                throw new EntityAccessException(currentUser.UserId, job.Id, typeof(Job));
            }
            var contractor = await userRepository.GetByIdAsync(request.ContractorId);

            job.AssignContractor(contractor);
            await jobRepository.UpdateAsync(job);

            return Unit.Value;
        }
    }
}
