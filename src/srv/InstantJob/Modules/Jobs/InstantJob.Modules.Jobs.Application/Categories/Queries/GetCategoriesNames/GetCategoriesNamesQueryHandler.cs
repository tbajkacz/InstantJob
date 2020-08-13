using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstantJob.Modules.Jobs.Application.Categories.Abstractions;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Categories.Queries.GetCategoriesNames
{
    public class GetCategoriesNamesQueryHandler : IRequestHandler<GetCategoriesNamesQuery, IEnumerable<CategoryNameDto>>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public GetCategoriesNamesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public Task<IEnumerable<CategoryNameDto>> Handle(GetCategoriesNamesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(categoryRepository.Get().Select(mapper.Map<CategoryNameDto>));
        }
    }
}
