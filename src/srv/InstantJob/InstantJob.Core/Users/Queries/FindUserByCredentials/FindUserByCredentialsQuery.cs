﻿using InstantJob.Domain.Users.Entities;
using MediatR;

namespace InstantJob.Core.Users.Queries.FindUserByCredentials
{
    public class FindUserByCredentialsQuery : IRequest<User>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
