using System;
using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Jobs.Application.Categories.Abstractions;
using InstantJob.Modules.Jobs.Domain.Categories;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Categories.Commands.AddCategory
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
            await categoryRepository.AddAsync(new Category(Guid.NewGuid(), request.Name, request.Description));
            return Unit.Value;
        }
    }
}
