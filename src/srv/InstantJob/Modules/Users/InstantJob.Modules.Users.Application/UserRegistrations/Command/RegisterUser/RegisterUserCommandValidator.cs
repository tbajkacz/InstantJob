namespace InstantJob.Modules.Users.Application.UserRegistrations.Command.RegisterUser
{
    public class RegisterUserCommandValidator : BaseUserRegistrationsValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleForName(x => x.Name);
            RuleForSurname(x => x.Surname);
            RuleForEmail(x => x.Email);
            RuleForPassword(x => x.Password);
            RuleForRoles(x => x.RoleId);
        }
    }
}
