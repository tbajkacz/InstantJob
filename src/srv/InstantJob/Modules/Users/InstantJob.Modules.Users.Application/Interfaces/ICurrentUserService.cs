using System.Collections.Generic;
using InstantJob.Modules.Users.Domain.Users;

namespace InstantJob.Modules.Users.Application.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }

        Role Role { get; }

        string Email { get; }
    }
}
