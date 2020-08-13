using System;
using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Users.Application.UserRegistrations.Command.Abstractions
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }

        Role Role { get; }

        string Email { get; }
    }
}
