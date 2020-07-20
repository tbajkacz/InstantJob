using MediatR;

namespace InstantJob.Modules.Jobs.Application.Commands.UpdateCategoryDescription
{
    public class UpdateCategoryDescriptionCommand : IRequest
    {
        public int CategoryId { get; set; }

        public string Description { get; set; }
    }
}
