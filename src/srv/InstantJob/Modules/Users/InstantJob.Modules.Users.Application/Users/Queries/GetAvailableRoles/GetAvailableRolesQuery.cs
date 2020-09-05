using InstantJob.BuildingBlocks.Domain;
using MediatR;
using System.Collections.Generic;

namespace InstantJob.Modules.Users.Application.Users.Queries.GetAvailableRoles
{
    public class GetAvailableRolesQuery : IRequest<List<Role>>
    {
    }
}
