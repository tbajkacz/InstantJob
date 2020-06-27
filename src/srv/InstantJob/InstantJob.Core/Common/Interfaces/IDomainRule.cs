namespace InstantJob.Core.Common.Interfaces
{
    public interface IDomainRule
    {
        public bool IsFailed();

        public string Message { get; }
    }
}
