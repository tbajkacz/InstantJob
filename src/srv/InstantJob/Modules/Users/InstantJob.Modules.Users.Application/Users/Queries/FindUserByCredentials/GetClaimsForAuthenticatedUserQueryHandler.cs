using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Common.Abstractions;
using InstantJob.Modules.Users.Application.UserRegistrations.Abstractions;
using InstantJob.Modules.Users.Application.Users.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace InstantJob.Modules.Users.Application.Users.Queries.FindUserByCredentials
{
    public class GetClaimsForAuthenticatedUserQueryHandler : IRequestHandler<GetClaimsForAuthenticatedUserQuery, ClaimsPrincipal>
    {
        private readonly IUserRepository users;
        private readonly IHashService hashService;

        public GetClaimsForAuthenticatedUserQueryHandler(IUserRepository users, IHashService hashService)
        {
            this.users = users;
            this.hashService = hashService;
        }

        public async Task<ClaimsPrincipal> Handle(GetClaimsForAuthenticatedUserQuery request, CancellationToken cancellationToken)
        {
            var user = await users.GetByEmailOrDefaultAsync(request.Email);

            if (user == null ||
                !hashService.CompareHashes(request.Password, user.PasswordHash))
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Id.ToString()),
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
        }
    }
}
