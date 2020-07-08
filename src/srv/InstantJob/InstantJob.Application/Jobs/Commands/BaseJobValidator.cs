using FluentValidation;
using System;
using System.Linq.Expressions;

namespace InstantJob.Core.Jobs.Commands
{
    public class BaseJobValidator<T> : AbstractValidator<T>
    {
        protected void RuleForTitle(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .NotNull()
                .Length(2, 50);
        }

        protected void RuleForDescription(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .NotNull()
                .MaximumLength(250);
        }

        protected void RuleForPrice(Expression<Func<T, decimal>> expression)
        {
            RuleFor(expression)
                .GreaterThanOrEqualTo(0);
        }

        protected void RuleForDeadline(Expression<Func<T, DateTime?>> expression)
        {
            RuleFor(expression)
                .Must(x => x == null || x > DateTime.UtcNow)
                .WithMessage("Deadline can't be in the past");
        }
    }
}
