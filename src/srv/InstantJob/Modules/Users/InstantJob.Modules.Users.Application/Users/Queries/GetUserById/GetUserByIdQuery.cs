using MediatR;
using System;

namespace InstantJob.Modules.Users.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserByIdDto>
    {
        public Guid UserId { get; set; }
    }
}
