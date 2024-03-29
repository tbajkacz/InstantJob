﻿using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Application.Users.Abstractions;
using MediatR;

namespace InstantJob.Modules.Users.Application.Users.Queries.GetUserRolesQuery
{
    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQuery, Role>
    {
        private readonly IUserRepository users;

        public GetUserRoleQueryHandler(IUserRepository users)
        {
            this.users = users;
        }

        public async Task<Role> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            return (await users.GetByIdAsync(request.Id)).Role;
        }
    }
}
