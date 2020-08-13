using System.Collections.Generic;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetDifficulties
{
    public class GetDifficultiesQuery : IRequest<IEnumerable<Difficulty>>
    {
    }
}
