namespace InstantJob.Core.Common.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }

        string Type { get; }

        string Email { get; }
    }
}
