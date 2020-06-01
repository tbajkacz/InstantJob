using InstantJob.Core.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace InstantJob.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int? UserId { get; }

        public string Type { get; }

        public string Email { get; set; }

        public CurrentUserService(IHttpContextAccessor accessor)
        {
            if (int.TryParse(FindClaim(accessor, ClaimTypes.NameIdentifier), out int id))
            {
                UserId = id;
                Type = FindClaim(accessor, ClaimTypes.Role);
                Email = FindClaim(accessor, ClaimTypes.Email);
            }
        }

        private string FindClaim(IHttpContextAccessor accessor, string type)
        {
            return accessor.HttpContext?.User?.FindFirst(c => c.Type == type)?.Value;
        }
    }
}
