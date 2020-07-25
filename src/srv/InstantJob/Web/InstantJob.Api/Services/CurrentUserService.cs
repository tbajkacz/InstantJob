using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace InstantJob.Web.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int UserId { get; }

        public Role Role { get; }

        public string Email { get; }

        public CurrentUserService(IHttpContextAccessor accessor)
        {
            if (int.TryParse(FindClaim(accessor, ClaimTypes.NameIdentifier), out int id) &&
                int.TryParse(FindClaim(accessor, ClaimTypes.Role), out int roleId))
            {
                UserId = id;
                Role = Enumeration.FromInt<Role>(roleId);
                Email = FindClaim(accessor, ClaimTypes.Email);
            }
        }

        private string FindClaim(IHttpContextAccessor accessor, string type)
        {
            return accessor.HttpContext?.User?.FindFirst(c => c.Type == type)?.Value;
        }
    }
}
