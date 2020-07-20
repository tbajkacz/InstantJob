using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using InstantJob.Modules.Users.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace InstantJob.Web.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int UserId { get; }

        public IEnumerable<string> Roles { get; }

        public string Email { get; }

        public CurrentUserService(IHttpContextAccessor accessor)
        {
            if (int.TryParse(FindClaim(accessor, ClaimTypes.NameIdentifier), out int id))
            {
                UserId = id;
                Roles = accessor.HttpContext?.User?.FindAll(c => c.Type == ClaimTypes.Role)?.Select(c => c.Value);
                Email = FindClaim(accessor, ClaimTypes.Email);
            }
        }

        private string FindClaim(IHttpContextAccessor accessor, string type)
        {
            return accessor.HttpContext?.User?.FindFirst(c => c.Type == type)?.Value;
        }
    }
}
