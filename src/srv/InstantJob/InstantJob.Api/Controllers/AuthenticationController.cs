using InstantJob.Core.Common.Interfaces;
using InstantJob.Core.Users.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InstantJob.Api.Controllers
{
    public class AuthenticationController : RoutedApiController
    {
        private readonly IUserManager userManager;

        public AuthenticationController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task SignIn(UserAuthParams param)
        {
            var user = await userManager.ValidateCredentialsAsync(param);

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
        public async Task Register(UserRegisterParams param)
        {
            await userManager.CreateAsync(param);
        }

        [HttpPost]
        public async Task ChangePassword(UserUpdatePasswordParams param)
        {
            await userManager.UpdatePasswordAsync(param);
        }

        [HttpPost]
        public async Task UpdateInformation(UserUpdateInfoParams param)
        {
            await userManager.UpdateInformationAsync(param);
        }
    }
}
