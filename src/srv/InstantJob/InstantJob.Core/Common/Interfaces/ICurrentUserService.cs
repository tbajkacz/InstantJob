namespace InstantJob.Core.Common.Interfaces
{
    public interface ICurrentUserService
    {
        public int? UserId { get; }

        public string Type { get; }
    }
}
