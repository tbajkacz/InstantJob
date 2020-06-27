namespace InstantJob.Domain.Common
{
    public interface IDomainRule
    {
        public bool IsFailed();

        public string Message { get; }
    }
}
