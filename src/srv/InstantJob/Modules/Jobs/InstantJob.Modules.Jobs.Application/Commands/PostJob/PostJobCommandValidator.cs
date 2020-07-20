namespace InstantJob.Core.Jobs.Commands.PostJob
{
    public class PostJobCommandValidator : BaseJobValidator<PostJobCommand>
    {
        public PostJobCommandValidator()
        {
            RuleForTitle(x => x.Title);
            RuleForDescription(x => x.Description);
            RuleForPrice(x => x.Price);
            RuleForDeadline(x => x.Deadline);
        }
    }
}
