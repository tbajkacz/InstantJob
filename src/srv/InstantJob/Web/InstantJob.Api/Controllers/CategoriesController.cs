using System.Collections.Generic;
using System.Threading.Tasks;
using InstantJob.Modules.Jobs.Application.Categories.Commands.AddCategory;
using InstantJob.Modules.Jobs.Application.Categories.Commands.UpdateCategoryDescription;
using InstantJob.Modules.Jobs.Application.Categories.Queries.GetCategoriesNames;
using InstantJob.Web.Api.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstantJob.Web.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CategoryNameDto>> GetCategoriesNames()
        {
            return await mediator.Send(new GetCategoriesNamesQuery());
        }

        /// <summary>
        /// Creates a new category
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policies.Administrator)]
        public async Task AddCategory(AddCategoryCommand command)
        {
            await mediator.Send(command);
        }

        /// <summary>
        /// Updates the specified categories description
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch]
        [Authorize(Policies.Administrator)]
        public async Task UpdateCategoryDescription(UpdateCategoryDescriptionCommand command)
        {
            await mediator.Send(command);
        }
    }
}
