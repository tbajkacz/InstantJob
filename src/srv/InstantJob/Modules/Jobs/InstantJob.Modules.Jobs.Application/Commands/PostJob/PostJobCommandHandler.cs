using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Commands.PostJob
{
    public class PostJobCommandHandler : IRequestHandler<PostJobCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMandatorRepository mandatorRepository;
        private readonly ICurrentMandatorService currentMandator;

        public PostJobCommandHandler(
            IJobRepository jobRepository,
            ICategoryRepository categoryRepository,
            IMandatorRepository mandatorRepository,
            ICurrentMandatorService currentMandator)
        {
            this.jobRepository = jobRepository;
            this.categoryRepository = categoryRepository;
            this.mandatorRepository = mandatorRepository;
            this.currentMandator = currentMandator;
        }

        public async Task<Unit> Handle(PostJobCommand request, CancellationToken cancellationToken)
        {
            await jobRepository.AddAsync(
                new Job(
                    request.Title,
                    request.Description,
                    request.Price,
                    request.Deadline,
                    Enumeration.FromInt<Difficulty>(request.DifficultyId),
                    await categoryRepository.GetByIdAsync(request.CategoryId),
                    await mandatorRepository.GetByIdAsync(currentMandator.Id))
                );
            return Unit.Value;
        }
    }
}
