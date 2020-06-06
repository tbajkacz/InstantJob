using FluentValidation;
using InstantJob.Core.Users.Constants;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace InstantJob.Core.Users.Validators
{
    public abstract class BaseUserValidator<T> : AbstractValidator<T>
    {
        protected void RuleForName(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .Length(2, 20)
                .NotNull();
        }

        protected void RuleForSurname(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .Length(2, 20)
                .NotNull();
        }

        protected void RuleForEmail(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .EmailAddress();
        }

        protected void RuleForPassword(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .Length(5, 20)
                .NotNull();
        }

        protected void RuleForType(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .Must(x => Roles.RolesCollection.Contains(x));
        }
    }
}
