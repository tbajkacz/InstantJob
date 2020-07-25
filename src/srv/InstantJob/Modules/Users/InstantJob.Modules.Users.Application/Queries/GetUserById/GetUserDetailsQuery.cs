using MediatR;

namespace InstantJob.Modules.Users.Application.Queries.GetUserById
{
    public class GetUserDetailsQuery : IRequest<UserDetailsDto>
    {
    }
}
