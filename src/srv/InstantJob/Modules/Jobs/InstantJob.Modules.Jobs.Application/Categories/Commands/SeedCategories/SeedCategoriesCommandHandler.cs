using InstantJob.Modules.Jobs.Application.Categories.Abstractions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Modules.Jobs.Application.Categories.Commands.SeedCategories
{
    public class SeedCategoriesCommandHandler : IRequestHandler<SeedCategoriesCommand>
    {
        private readonly ICategoryRepository categoryRepository;

        public SeedCategoriesCommandHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(SeedCategoriesCommand request, CancellationToken cancellationToken)
        {
            if (categoryRepository.Get().Any())
            {
                return Unit.Value;
            }

            // TODO AddRange
            foreach (var category in request.Categories)
            {
                await categoryRepository.AddAsync(category);
            }

            return Unit.Value;
        }
    }
}
