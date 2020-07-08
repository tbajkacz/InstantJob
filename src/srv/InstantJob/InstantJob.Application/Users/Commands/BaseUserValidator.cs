using FluentValidation;
using InstantJob.Domain.Users.Constants;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace InstantJob.Core.Users.Commands
{
    public abstract class BaseUserValidator<T> : AbstractValidator<T>
    {
        protected void RuleForName(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .NotNull()
                .Length(2, 50);
        }

        protected void RuleForSurname(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .NotNull()
                .Length(2, 50);
        }

        protected void RuleForEmail(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .EmailAddress();
        }

        protected void RuleForPassword(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .NotNull()
                .Length(5, 50);
        }

        protected void RuleForType(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .Must(x => Roles.RolesCollection.Contains(x));
        }
    }
}
