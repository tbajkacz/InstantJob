using System.Collections.Generic;
using InstantJob.Modules.Users.Domain.Constants;
using MediatR;

namespace InstantJob.Modules.Users.Application.Queries.GetUserRolesQuery
{
    public class GetUserRolesQuery : IRequest<IReadOnlyCollection<string>>
    {
        public int Id { get; set; }
    }
}
