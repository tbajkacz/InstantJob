namespace InstantJob.Modules.Users.Application.Users.Commands.ChangeUserPassword
{
    public class ChangeUserPasswordCommandValidator : BaseUserValidator<ChangeUserPasswordCommand>
    {
        public ChangeUserPasswordCommandValidator()
        {
            RuleForPassword(x => x.Password);
        }
    }
}
