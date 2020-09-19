using System.Collections.Generic;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
