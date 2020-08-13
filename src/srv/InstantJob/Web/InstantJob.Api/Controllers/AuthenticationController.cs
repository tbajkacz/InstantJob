using System.Net;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Users.Commands.ChangeUserPassword;
using InstantJob.Modules.Users.Application.Users.Commands.UpdateUserInformation;
using InstantJob.Modules.Users.Application.Users.Queries.FindUserByCredentials;
using InstantJob.Modules.Users.Application.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InstantJob.Web.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task SignIn(GetClaimsForAuthenticatedUserQuery query)
        {
            //TODO refactor into command
            var claims = await mediator.Send(query);

            if (claims == null)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claims, new AuthenticationProperties { AllowRefresh = true});
        }

        [HttpPost("signout")]
        public async Task SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpGet("user")]
        public async Task<UserDetailsDto> GetCurrentUser()
        {
            return await mediator.Send(new GetUserDetailsQuery());
        }

        [HttpPatch("user/password")]
        public async Task ChangePassword(ChangeUserPasswordCommand command)
        {
            await mediator.Send(command);
        }

        [HttpPatch("user/info")]
        public async Task UpdateInformation(UpdateUserInformationCommand command)
        {
            await mediator.Send(command);
        }
    }
}
