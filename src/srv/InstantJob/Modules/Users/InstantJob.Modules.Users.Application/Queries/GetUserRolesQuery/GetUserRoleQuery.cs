using System;
using InstantJob.BuildingBlocks.Domain;
using MediatR;

namespace InstantJob.Modules.Users.Application.Queries.GetUserRolesQuery
{
    public class GetUserRoleQuery : IRequest<Role>
    {
        public Guid Id { get; set; }
    }
}
