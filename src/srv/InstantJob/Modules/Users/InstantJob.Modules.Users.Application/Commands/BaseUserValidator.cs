using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using InstantJob.Modules.Users.Domain.Constants;

namespace InstantJob.Modules.Users.Application.Commands
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

        protected void RuleForRoles(Expression<Func<T, IEnumerable<string>>> expression)
        {
            RuleFor(expression)
                .Must(x => x.All(Roles.RolesCollection.Contains));
        }
    }
}
