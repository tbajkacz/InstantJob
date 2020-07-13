namespace InstantJob.Domain.Common
{
    public interface IDomainRule
    {
        public bool IsViolated();

        public string Message { get; }
    }
}
