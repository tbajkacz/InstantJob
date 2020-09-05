using InstantJob.BuildingBlocks.Domain;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Modules.Users.Application.Users.Queries.GetAvailableRoles
{
    public class GetAvailableRolesQueryHandler : IRequestHandler<GetAvailableRolesQuery, List<Role>>
    {
        public Task<List<Role>> Handle(GetAvailableRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = Enumeration.GetAll<Role>().ToList();
            roles.Remove(Role.Administrator);

            return Task.FromResult(roles);
        }
    }
}
