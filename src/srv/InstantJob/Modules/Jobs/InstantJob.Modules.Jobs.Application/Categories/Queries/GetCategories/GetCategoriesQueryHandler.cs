using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstantJob.Modules.Jobs.Application.Categories.Abstractions;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(categoryRepository.Get().Select(mapper.Map<CategoryDto>));
        }
    }
}
