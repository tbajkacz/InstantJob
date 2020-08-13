using System.Collections.Generic;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Categories.Queries.GetCategoriesNames
{
    public class GetCategoriesNamesQuery : IRequest<IEnumerable<CategoryNameDto>>
    {
    }
}
