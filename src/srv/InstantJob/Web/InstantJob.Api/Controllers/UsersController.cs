using InstantJob.Modules.Users.Application.Users.Commands.ChangeUserPassword;
using InstantJob.Modules.Users.Application.Users.Commands.UpdateUserInformation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InstantJob.Web.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Changes current users password
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("user/password")]
        public async Task ChangePassword(ChangeUserPasswordCommand command)
        {
            await mediator.Send(command);
        }

        /// <summary>
        /// Updates current users information
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("user/info")]
        public async Task UpdateInformation(UpdateUserInformationCommand command)
        {
            await mediator.Send(command);
        }
    }
}
