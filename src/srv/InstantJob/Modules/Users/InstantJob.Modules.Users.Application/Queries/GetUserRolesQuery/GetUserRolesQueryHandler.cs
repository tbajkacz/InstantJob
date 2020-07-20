using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Domain.Constants;
using MediatR;

namespace InstantJob.Modules.Users.Application.Queries.GetUserRolesQuery
{
    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, IReadOnlyCollection<string>>
    {
        public Task<IReadOnlyCollection<string>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Roles.RolesCollection);
        }
    }
}
