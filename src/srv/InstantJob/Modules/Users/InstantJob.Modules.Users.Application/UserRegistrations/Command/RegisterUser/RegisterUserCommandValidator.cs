using FluentValidation;

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
            RuleFor(x => x.PasswordConfirmation)
                .Equal(x => x.Password)
                .WithMessage("Passwords must match");
        }
    }
}
