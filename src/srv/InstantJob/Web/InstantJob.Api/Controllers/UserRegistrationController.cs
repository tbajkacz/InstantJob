﻿using System;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.UserRegistrations.Command.ConfirmRegistration;
using InstantJob.Modules.Users.Application.UserRegistrations.Command.RegisterUser;
using InstantJob.Web.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InstantJob.Web.Api.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserRegistrationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<CreateResponse<Guid>> Register(RegisterUserCommand command)
        {
            return new CreateResponse<Guid>(await mediator.Send(command));
        }

        [HttpPatch]
        public async Task ConfirmRegistration(ConfirmRegistrationCommand command)
        {
            await mediator.Send(command);
        }
    }
}
