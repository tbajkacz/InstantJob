using InstantJob.Core.Users.Commands.ChangeUserPassword;
using InstantJob.Core.Users.Commands.CreateUser;
using InstantJob.Core.Users.Commands.UpdateUserInformation;
using InstantJob.Core.Users.Queries.FindUserByCredentials;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InstantJob.Api.Controllers
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
            var user = await mediator.Send(query);

            if (user == null)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.Type),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties { AllowRefresh = true});
        }

        [HttpPost]
        public async Task SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpPost]
        public async Task Register(CreateUserCommand command)
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
