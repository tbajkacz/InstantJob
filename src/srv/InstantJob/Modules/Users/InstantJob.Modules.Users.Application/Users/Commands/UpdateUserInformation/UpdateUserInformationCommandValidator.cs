namespace InstantJob.Modules.Users.Application.Users.Commands.UpdateUserInformation
{
    public class UpdateUserInformationCommandValidator : BaseUserValidator<UpdateUserInformationCommand>
    {
        public UpdateUserInformationCommandValidator()
        {
            RuleForName(x => x.Name);
            RuleForSurname(x => x.Surname);
        }
    }
}
