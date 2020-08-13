using System.Security.Claims;
using MediatR;

namespace InstantJob.Modules.Users.Application.Users.Queries.FindUserByCredentials
{
    public class GetClaimsForAuthenticatedUserQuery : IRequest<ClaimsPrincipal>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
