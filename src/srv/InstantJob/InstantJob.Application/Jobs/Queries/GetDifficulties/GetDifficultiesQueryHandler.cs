using InstantJob.Domain.Jobs.Constants;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Application.Jobs.Queries.GetDifficulties
{
    public class GetDifficultiesQueryHandler : IRequestHandler<GetDifficultiesQuery, IEnumerable<Difficulty>>
    {
        public Task<IEnumerable<Difficulty>> Handle(GetDifficultiesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Difficulty.GetAll<Difficulty>());
        }
    }
}
