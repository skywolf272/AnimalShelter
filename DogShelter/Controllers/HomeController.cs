using DogShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DogShelter.Data;
using Microsoft.AspNetCore.Identity;

namespace DogShelter.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext DB;

        public HomeController(AppDbContext dbContext, ILogger<HomeController> logger)
        {
            DB = dbContext;

            string AdminID = Guid.NewGuid().ToString();
            string AdminRoleID = Guid.NewGuid().ToString();

            IdentityRole adminRole = new IdentityRole()
            {
                Id = AdminRoleID,
                Name = "admin",
                NormalizedName = "ADMIN"
            };
            DB.Roles.Add(adminRole);
            var Hasher = new PasswordHasher<IdentityUser>();
            User adminUser = new User()
            {
                Id = AdminID,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                PasswordHash = Hasher.HashPassword(null, "admin")
            };
            DB.Users.Add(adminUser);
            IdentityUserRole<string> adminUserRole = new IdentityUserRole<string>()
            {
                UserId = AdminID,
                RoleId = AdminRoleID
            };
            DB.UserRoles.Add(adminUserRole);
            DB.SaveChanges();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            NewsViewModel viewModel = new NewsViewModel();
            viewModel.News = DB.News.ToList();
            viewModel.NewestDogs = DB.DogPosts.Take(3).ToList();
            return View(viewModel);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult CurrentNew(int NewID)
        {
            News currentNew = DB.News.Where(x => x.ID == NewID).FirstOrDefault();
            return View(currentNew);
        }
    }
}
