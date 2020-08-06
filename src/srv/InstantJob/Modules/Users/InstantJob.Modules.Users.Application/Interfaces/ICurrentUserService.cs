using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Users.Application.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }

        Role Role { get; }

        string Email { get; }
    }
}
