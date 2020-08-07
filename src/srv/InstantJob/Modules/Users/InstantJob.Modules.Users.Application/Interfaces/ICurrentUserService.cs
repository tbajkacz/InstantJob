using System;
using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Users.Application.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }

        Role Role { get; }

        string Email { get; }
    }
}
