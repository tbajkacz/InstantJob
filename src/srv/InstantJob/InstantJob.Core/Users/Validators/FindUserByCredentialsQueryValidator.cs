using InstantJob.Core.Users.Queries;

namespace InstantJob.Core.Users.Validators
{
    public class FindUserByCredentialsQueryValidator : BaseUserValidator<FindUserByCredentialsQuery>
    {
        public FindUserByCredentialsQueryValidator()
        {
            RuleForEmail(x => x.Email);
            RuleForPassword(x => x.Password);
        }
    }
}
