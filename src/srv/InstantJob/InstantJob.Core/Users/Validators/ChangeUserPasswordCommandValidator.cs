using InstantJob.Core.Users.Commands;

namespace InstantJob.Core.Users.Validators
{
    public class ChangeUserPasswordCommandValidator : BaseUserValidator<ChangeUserPasswordCommand>
    {
        public ChangeUserPasswordCommandValidator()
        {
            RuleForPassword(x => x.Password);
        }
    }
}
