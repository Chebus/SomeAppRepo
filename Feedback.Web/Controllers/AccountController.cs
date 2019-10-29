using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Feedback.Database.Interfaces;
using Feedback.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.UserInterface.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /<controller>/
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View("Login");
        }

        // POST: /<controller>/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserViewModel vm)
        {
            var user = await _userService.Authenticate(vm.Id, vm.Password);
            await Login(user.Id);

            //todo: handle errors

            //redirect user back to page they were trying to get to (TODO: verify this works)
            var redirectUrl = Request.Query["ReturnUrl"];
            if (string.IsNullOrEmpty(redirectUrl))
            {
                return RedirectToAction("Index", "Review");
            }

            return Redirect(redirectUrl);
        }

        // GET: /<controller>/Logout
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index");
        }

        private async Task Login(string userId)
        {
            //store the user ID claim
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }
    }
}
