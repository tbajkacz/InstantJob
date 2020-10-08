using MediatR;

namespace InstantJob.Modules.Users.Application.Users.Queries.FindByName
{
    public class FindByNameQuery : IRequest<FindByNameDto>
    {
        public string Search { get; set; }
    }
}
