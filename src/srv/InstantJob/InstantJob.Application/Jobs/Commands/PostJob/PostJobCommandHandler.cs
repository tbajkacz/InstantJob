using InstantJob.Core.Common.Interfaces;
using InstantJob.Domain.Jobs.Constants;
using InstantJob.Domain.Jobs.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Core.Jobs.Commands.PostJob
{
    public class PostJobCommandHandler : IRequestHandler<PostJobCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUserRepository userRepository;
        private readonly ICurrentUserService currentUser;

        public PostJobCommandHandler(
            IJobRepository jobRepository,
            ICategoryRepository categoryRepository,
            IUserRepository userRepository,
            ICurrentUserService currentUser)
        {
            this.jobRepository = jobRepository;
            this.categoryRepository = categoryRepository;
            this.userRepository = userRepository;
            this.currentUser = currentUser;
        }

        public async Task<Unit> Handle(PostJobCommand request, CancellationToken cancellationToken)
        {
            await jobRepository.AddAsync(
                new Job(
                    request.Title,
                    request.Description,
                    request.Price,
                    request.Deadline,
                    (Difficulty)request.DifficultyId,
                    await categoryRepository.GetByIdAsync(request.CategoryId),
                    await userRepository.GetByIdAsync(currentUser.UserId))
                );
            return Unit.Value;
        }
    }
}
