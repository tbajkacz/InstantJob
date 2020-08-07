﻿using System;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Users.Domain.Users;

namespace InstantJob.Modules.Users.Application.Interfaces
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> FindByEmailAsync(string email);
    }
}
