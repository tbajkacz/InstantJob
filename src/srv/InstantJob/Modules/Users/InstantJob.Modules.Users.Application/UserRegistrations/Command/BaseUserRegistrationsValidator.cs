﻿using System;
using System.Linq.Expressions;
using FluentValidation;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Application.Users.Commands;

namespace InstantJob.Modules.Users.Application.UserRegistrations.Command
{
    public class BaseUserRegistrationsValidator<T> : BaseUserValidator<T>
    {
        protected override void RuleForRoles(Expression<Func<T, int>> expression)
        {
            RuleFor(expression)
                .Must(x => Enumeration.ContainsId<Role>(x) && Enumeration.FromInt<Role>(x) != Role.Administrator);
            base.RuleForRoles(expression);
        }
    }
}
