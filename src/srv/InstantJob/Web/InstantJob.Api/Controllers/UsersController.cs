using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Application.Users.Commands.ChangeUserPassword;
using InstantJob.Modules.Users.Application.Users.Commands.UpdateUserInformation;
using InstantJob.Modules.Users.Application.Users.Queries.GetAvailableRoles;
using InstantJob.Modules.Users.Application.Users.Queries.GetUserById;
using InstantJob.Modules.Users.Application.Users.Queries.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        /// Returns user info for the id specified in route
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public Task<UserByIdDto> GetUserInfo(Guid userId)
        {
            return mediator.Send(new GetUserByIdQuery { UserId = userId });
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

        /// <summary>
        /// Gets available user roles
        /// </summary>
        /// <returns></returns>
        [HttpGet("roles")]
        [AllowAnonymous]
        public async Task<IEnumerable<Role>> GetAvailableRoles()
        {
            return await mediator.Send(new GetAvailableRolesQuery());
        }
    }
}
