using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Queries.GetDifficulties
{
    public class GetDifficultiesQueryHandler : IRequestHandler<GetDifficultiesQuery, IEnumerable<Difficulty>>
    {
        public Task<IEnumerable<Difficulty>> Handle(GetDifficultiesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Difficulty.GetAll<Difficulty>());
        }
    }
}
