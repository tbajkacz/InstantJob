using InstantJob.Core.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Core.Jobs.Commands.ApplyForJob
{
    public class ApplyForJobCommandHandler : IRequestHandler<ApplyForJobCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly IUserRepository userRepository;
        private readonly ICurrentUserService currentUser;

        public ApplyForJobCommandHandler(
            IJobRepository jobRepository,
            IUserRepository userRepository,
            ICurrentUserService currentUser)
        {
            this.jobRepository = jobRepository;
            this.userRepository = userRepository;
            this.currentUser = currentUser;
        }

        public async Task<Unit> Handle(ApplyForJobCommand request, CancellationToken cancellationToken)
        {
            var contractor = await userRepository.GetByIdAsync(currentUser.UserId);
            var job = await jobRepository.GetByIdAsync(request.JobId);

            job.ApplyForJob(contractor);

            await jobRepository.UpdateAsync(job);
            return Unit.Value;
        }
    }
}
