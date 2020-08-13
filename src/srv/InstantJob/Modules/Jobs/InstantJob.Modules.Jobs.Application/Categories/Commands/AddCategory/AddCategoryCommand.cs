using MediatR;

namespace InstantJob.Modules.Jobs.Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
