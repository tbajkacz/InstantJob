using AutoMapper;
using InstantJob.Modules.Users.Application.Users.Abstractions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Modules.Users.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserByIdDto>
    {
        private readonly IUserRepository users;
        private readonly IMapper mapper;

        public GetUserByIdQueryHandler(IUserRepository users, IMapper mapper)
        {
            this.users = users;
            this.mapper = mapper;
        }

        public async Task<UserByIdDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await users.GetByIdAsync(request.UserId);

            return mapper.Map<UserByIdDto>(user);
        }
    }
}
