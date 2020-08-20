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

        /// <summary>
        /// Validates user credentials and generates an authentication cookie
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task SignIn(GetClaimsForAuthenticatedUserQuery query)
        {
            var claims = await mediator.Send(query);

            if (claims == null)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claims, new AuthenticationProperties { AllowRefresh = true});
        }

        /// <summary>
        /// Signs the user out
        /// </summary>
        /// <returns></returns>
        [HttpPost("signout")]
        public async Task SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// Gets information about the currently logged in user
        /// </summary>
        /// <returns></returns>
        [HttpGet("user")]
        public async Task<UserDetailsDto> GetCurrentUser()
        {
            return await mediator.Send(new GetUserDetailsQuery());
        }
    }
}
