using MediatR;

namespace InstantJob.Core.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
