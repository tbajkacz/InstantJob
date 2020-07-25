using System;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Domain.Users;

namespace InstantJob.Modules.Users.Application.Commands
{
    public abstract class BaseUserValidator<T> : AbstractValidator<T>
    {
        protected virtual void RuleForName(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .NotNull()
                .Length(2, 50);
        }

        protected virtual void RuleForSurname(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .NotNull()
                .Length(2, 50);
        }

        protected virtual void RuleForEmail(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .EmailAddress();
        }

        protected virtual void RuleForPassword(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .NotNull()
                .Length(5, 50);
        }

        protected virtual void RuleForRoles(Expression<Func<T, int>> expression)
        {
            RuleFor(expression)
                .Must(x => Enumeration.GetAll<Role>().Any(r => r.Id == x));
        }
    }
}
