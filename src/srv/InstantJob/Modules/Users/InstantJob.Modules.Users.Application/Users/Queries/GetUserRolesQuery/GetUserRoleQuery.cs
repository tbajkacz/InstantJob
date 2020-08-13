using System;
using InstantJob.BuildingBlocks.Domain;
using MediatR;

namespace InstantJob.Modules.Users.Application.Users.Queries.GetUserRolesQuery
{
    public class GetUserRoleQuery : IRequest<Role>
    {
        public Guid Id { get; set; }
    }
}
