using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreEntityPostgres.DBcontext;
using AspCoreEntityPostgres.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AspCoreEntityPostgres.Controllers
{
    public class AccountController : Controller
    {

        private readonly ApplicationContext _context;

        public AccountController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User model)
        {
            if (model.UserPassword == null) model.UserPassword = " ";
            if (ModelState.IsValid)
            {
                User user = await _context.Users.Include(r => r.Role)
                    .FirstOrDefaultAsync(u => u.UserLogin == model.UserLogin 
                    //&& u.UserPassword == model.UserPassword
                    ).ConfigureAwait(false);
                if (user != null)
                {
                    await Authenticate(user).ConfigureAwait(false); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View();
        }

        private async System.Threading.Tasks.Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserFIO),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.NameRole)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id)).ConfigureAwait(false);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).ConfigureAwait(false);
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Access ()
        {
            return View();
        }
    }
}