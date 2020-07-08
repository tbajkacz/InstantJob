namespace InstantJob.Core.Users.Commands.CreateUser
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
