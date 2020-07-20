namespace InstantJob.Modules.Users.Application.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordCommandValidator : BaseUserValidator<ChangeUserPasswordCommand>
    {
        public ChangeUserPasswordCommandValidator()
        {
            RuleForPassword(x => x.Password);
        }
    }
}
