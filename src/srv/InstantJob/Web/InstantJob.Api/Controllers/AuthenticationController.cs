using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.UserRegistrations.Command;
using InstantJob.Modules.Users.Application.UserRegistrations.Command.ConfirmRegistration;
using InstantJob.Modules.Users.Application.UserRegistrations.Command.RegisterUser;
using InstantJob.Modules.Users.Application.Users.Commands.ChangeUserPassword;
using InstantJob.Modules.Users.Application.Users.Commands.UpdateUserInformation;
using InstantJob.Modules.Users.Application.Users.Queries.FindUserByCredentials;
using InstantJob.Modules.Users.Application.Users.Queries.GetUserById;
using InstantJob.Web.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstantJob.Web.Api.Controllers
{
    [Authorize]
    public class AuthenticationController : RoutedApiController
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task SignIn(FindUserByCredentialsQuery query)
        {
            //TODO refactor into command
            var user = await mediator.Send(query);

            if (user == null)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Id.ToString()),
            };

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties { AllowRefresh = true});
        }

        [HttpPost]
        public async Task SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public async Task<UserDetailsDto> GetCurrentUser()
        {
            return await mediator.Send(new GetUserDetailsQuery());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<CreateResponse<Guid>> Register(RegisterUserCommand command)
        {
            return new CreateResponse<Guid>(await mediator.Send(command));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task ConfirmRegistration(ConfirmRegistrationCommand command)
        {
            await mediator.Send(command);
        }

        [HttpPut]
        public async Task ChangePassword(ChangeUserPasswordCommand command)
        {
            await mediator.Send(command);
        }

        [HttpPut]
        public async Task UpdateInformation(UpdateUserInformationCommand command)
        {
            await mediator.Send(command);
        }
    }
}
