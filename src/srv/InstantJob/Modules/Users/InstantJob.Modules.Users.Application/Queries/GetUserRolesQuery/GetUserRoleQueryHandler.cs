using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Domain.Users;
using MediatR;

namespace InstantJob.Modules.Users.Application.Queries.GetUserRolesQuery
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
