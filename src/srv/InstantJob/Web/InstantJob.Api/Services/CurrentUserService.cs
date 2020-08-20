using System;
using System.Linq;
using System.Security.Claims;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Application.Users.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InstantJob.Web.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public Guid UserId { get; }

        public Role Role { get; }

        public string Email { get; }

        public CurrentUserService(IHttpContextAccessor accessor)
        {
            if (Guid.TryParse(FindClaim(accessor, ClaimTypes.NameIdentifier), out Guid id))
            {
                UserId = id;
                Role = Enumeration.GetAll<Role>().SingleOrDefault(r => r.Name == FindClaim(accessor, ClaimTypes.Role));
                Email = FindClaim(accessor, ClaimTypes.Email);
            }
        }

        private string FindClaim(IHttpContextAccessor accessor, string type)
        {
            return accessor.HttpContext?.User?.FindFirst(c => c.Type == type)?.Value;
        }
    }
}
