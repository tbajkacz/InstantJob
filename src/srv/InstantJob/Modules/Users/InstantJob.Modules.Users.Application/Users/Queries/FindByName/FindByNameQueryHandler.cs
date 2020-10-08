using AutoMapper;
using InstantJob.Modules.Users.Application.Users.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Modules.Users.Application.Users.Queries.FindByName
{
    public class FindByNameQueryHandler : IRequestHandler<FindByNameQuery, FindByNameDto>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public FindByNameQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public Task<FindByNameDto> Handle(FindByNameQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Search))
            {
                return Task.FromResult(new FindByNameDto { Users = new List<FindByNameUserDto>() });
            }

            var matchedUsers = userRepository.Get()
                .Where(u => $"{u.Name} {u.Surname}".Contains(request.Search, StringComparison.InvariantCultureIgnoreCase))
                .Select(mapper.Map<FindByNameUserDto>)
                .ToList();

            return Task.FromResult(new FindByNameDto { Users = matchedUsers });
        }
    }
}
