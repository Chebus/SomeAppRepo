using Feedback.Database.Interfaces;
using Feedback.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Feedback.UserInterface.Controllers
{
    public class AccountController : BaseController
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
            var user = _userService.Authenticate(vm.Id, vm.Password);

            if (user == null)
            {
                //Login failed
                SetResultsMessage("The username or password are invalid. Please try again.", true);
                return View();
            }

            await Login(user.UserId);
            return RedirectToAction("Index", "Review");
        }

        // GET: /<controller>/Logout
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            SetResultsMessage("You have been signed out sucessfully!");

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
