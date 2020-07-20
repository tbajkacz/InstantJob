namespace InstantJob.BuildingBlocks.Domain
{
    public interface IDomainRule
    {
        public bool IsViolated();

        public string Message { get; }
    }
}
