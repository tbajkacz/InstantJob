using MediatR;
using System.Collections.Generic;

namespace InstantJob.Core.Categories.Queries.GetCategoriesNames
{
    public class GetCategoriesNamesQuery : IRequest<IEnumerable<CategoryNameDto>>
    {
    }
}
