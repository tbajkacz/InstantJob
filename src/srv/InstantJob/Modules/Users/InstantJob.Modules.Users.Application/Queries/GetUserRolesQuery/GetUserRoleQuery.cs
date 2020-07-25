using System.Collections.Generic;
using InstantJob.Modules.Users.Domain.Users;
using MediatR;

namespace InstantJob.Modules.Users.Application.Queries.GetUserRolesQuery
{
    public class GetUserRoleQuery : IRequest<Role>
    {
        public int Id { get; set; }
    }
}
