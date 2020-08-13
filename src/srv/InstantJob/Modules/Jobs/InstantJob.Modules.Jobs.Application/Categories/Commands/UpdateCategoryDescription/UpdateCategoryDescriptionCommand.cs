using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Categories.Commands.UpdateCategoryDescription
{
    public class UpdateCategoryDescriptionCommand : IRequest
    {
        public Guid CategoryId { get; set; }

        public string Description { get; set; }
    }
}
