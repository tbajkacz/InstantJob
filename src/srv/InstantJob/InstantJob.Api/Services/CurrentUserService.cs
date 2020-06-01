using InstantJob.Core.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace InstantJob.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor accessor)
        {
            if (int.TryParse(accessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                UserId = id;
                Type = accessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;
            }
        }

        public int? UserId { get; }

        public string Type { get; }
    }
}
