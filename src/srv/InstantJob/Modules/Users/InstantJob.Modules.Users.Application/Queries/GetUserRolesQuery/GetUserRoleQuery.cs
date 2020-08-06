using InstantJob.BuildingBlocks.Domain;
using MediatR;

namespace InstantJob.Modules.Users.Application.Queries.GetUserRolesQuery
{
    public class GetUserRoleQuery : IRequest<Role>
    {
        public int Id { get; set; }
    }
}
