using MediatR;

namespace InstantJob.Application.Categories.Commands.UpdateCategoryDescription
{
    public class UpdateCategoryDescriptionCommand : IRequest
    {
        public int CategoryId { get; set; }

        public string Description { get; set; }
    }
}
