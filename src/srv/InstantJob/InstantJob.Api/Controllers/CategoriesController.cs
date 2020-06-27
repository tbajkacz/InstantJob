using InstantJob.Core.Categories.Commands.AddCategory;
using InstantJob.Core.Categories.Queries.GetCategoriesNames;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstantJob.Api.Controllers
{
    [Authorize]
    public class CategoriesController : RoutedApiController
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryNameDto>> GetCategoriesNames()
        {
            return await mediator.Send(new GetCategoriesNamesQuery());
        }

        [HttpPost]
        public async Task AddCategory(AddCategoryCommand command)
        {
            await mediator.Send(command);
        }

        //TODO update should update only description, name change would mean a different entity
    }
}
