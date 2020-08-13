namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.UpdateJobDetails
{
    public class UpdateJobDetailsCommandValidator : BaseJobValidator<UpdateJobDetailsCommand>
    {
        public UpdateJobDetailsCommandValidator()
        {
            RuleForTitle(x => x.Title);
            RuleForDescription(x => x.Description);
            RuleForPrice(x => x.Price);
        }
    }
}
