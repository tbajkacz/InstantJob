using System.Collections.Generic;
using System.Threading.Tasks;
using InstantJob.Modules.Jobs.Application.Categories.Commands.AddCategory;
using InstantJob.Modules.Jobs.Application.Categories.Commands.UpdateCategoryDescription;
using InstantJob.Modules.Jobs.Application.Categories.Queries.GetCategoriesNames;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstantJob.Web.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
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

        [HttpPatch]
        public async Task UpdateCategoryDescription(UpdateCategoryDescriptionCommand command)
        {
            await mediator.Send(command);
        }
    }
}
