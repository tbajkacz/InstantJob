using System.Collections.Generic;

namespace InstantJob.Modules.Users.Application.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }

        IEnumerable<string> Roles { get; }

        string Email { get; }
    }
}
