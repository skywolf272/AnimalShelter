using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogShelter.Models;
using DogShelter.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace DogShelter.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext DB;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(AppDbContext _appDb, UserManager<User> _userManager, SignInManager<User> _signInManager, ILogger<AccountController> logger)
        {
            DB = _appDb;
            userManager = _userManager;
            signInManager = _signInManager;

            logger.LogDebug(DB.Users.FirstOrDefault().ToString());
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(model.Login);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Admin", new { area = "Admin"});
                    }
                }
                ModelState.AddModelError(nameof(model.Login), "Неверный логин или пароль");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
