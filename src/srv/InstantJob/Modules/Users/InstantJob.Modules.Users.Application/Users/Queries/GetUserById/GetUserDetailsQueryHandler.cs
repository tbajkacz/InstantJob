using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstantJob.Modules.Users.Application.UserRegistrations.Command.Abstractions;
using MediatR;

namespace InstantJob.Modules.Users.Application.Users.Queries.GetUserById
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsDto>
    {
        private readonly ICurrentUserService currentUser;
        private readonly IUserRepository users;
        private readonly IMapper mapper;

        public GetUserDetailsQueryHandler(ICurrentUserService currentUser, IUserRepository users, IMapper mapper)
        {
            this.currentUser = currentUser;
            this.users = users;
            this.mapper = mapper;
        }

        public async Task<UserDetailsDto> Handle(GetUserDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var user = await users.GetByIdAsync(currentUser.UserId);

            return mapper.Map<UserDetailsDto>(user);
        }
    }
}
