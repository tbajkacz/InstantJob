using System;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Users.Domain.UserRegistrations;

namespace InstantJob.Modules.Users.Application.UserRegistrations.Abstractions
{
    public interface IUserRegistrationRepository : IRepository<UserRegistration, Guid>
    {
    }
}
