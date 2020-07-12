using InstantJob.Domain.Jobs.Constants;
using MediatR;
using System.Collections.Generic;

namespace InstantJob.Application.Jobs.Queries.GetDifficulties
{
    public class GetDifficultiesQuery : IRequest<IEnumerable<Difficulty>>
    {
    }
}
