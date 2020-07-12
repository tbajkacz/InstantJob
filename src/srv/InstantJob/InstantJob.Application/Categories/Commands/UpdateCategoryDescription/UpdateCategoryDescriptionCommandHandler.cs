using InstantJob.Core.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Application.Categories.Commands.UpdateCategoryDescription
{
    public class UpdateCategoryDescriptionCommandHandler : IRequestHandler<UpdateCategoryDescriptionCommand>
    {
        private readonly ICategoryRepository categoryRepository;

        public UpdateCategoryDescriptionCommandHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateCategoryDescriptionCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.CategoryId);
            category.Description = request.Description;
            await categoryRepository.UpdateAsync(category);
            return Unit.Value;
        }
    }
}
