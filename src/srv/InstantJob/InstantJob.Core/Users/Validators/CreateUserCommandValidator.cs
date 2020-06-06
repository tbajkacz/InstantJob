using InstantJob.Core.Users.Commands;

namespace InstantJob.Core.Users.Validators
{
    public class CreateUserCommandValidator : BaseUserValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleForName(x => x.Name);
            RuleForSurname(x => x.Surname);
            RuleForEmail(x => x.Email);
            RuleForPassword(x => x.Password);
            RuleForType(x => x.Type);
        }
    }
}
