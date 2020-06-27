using InstantJob.Core.Common.Interfaces;
using InstantJob.Domain.Categories.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Core.Categories.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand>
    {
        private readonly ICategoryRepository categoryRepository;

        public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            await categoryRepository.AddAsync(new Category(request.Name, request.Description));
            return Unit.Value;
        }
    }
}
