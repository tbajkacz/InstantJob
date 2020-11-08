using InstantJob.Modules.Jobs.Domain.Categories;
using MediatR;
using System.Collections.Generic;

namespace InstantJob.Modules.Jobs.Application.Categories.Commands.SeedCategories
{
    public class SeedCategoriesCommand : IRequest
    {
        public List<Category> Categories { get; set; }
    }
}
