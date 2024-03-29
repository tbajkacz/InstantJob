﻿using System;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Infrastructure.Data;
using InstantJob.Modules.Users.Application.UserRegistrations.Abstractions;
using InstantJob.Modules.Users.Domain.UserRegistrations;
using NHibernate;

namespace InstantJob.Modules.Users.Infrastructure.Data
{
    public class NHibernateUserRegistrationRepository : NHibernateRepositoryBase<UserRegistration, Guid>, IUserRegistrationRepository
    {
        public NHibernateUserRegistrationRepository(ISession session) 
            : base(session)
        {
        }
    }
}
