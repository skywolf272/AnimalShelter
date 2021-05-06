using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DogShelter.Models;
using DogShelter.Data;
using Microsoft.AspNetCore.Authorization;


namespace DogShelter.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext DB;

        public ServiceController(AppDbContext _DB)
        {
            DB = _DB;
        }

        public IActionResult TakeCare()
        {
            return PartialView("TakeCare", new News { Title = "pivo" });
        }

        public IActionResult TakeDog()
        {
            return View(DB.DogPosts.ToList());
        }

        [HttpGet]
        public IActionResult GiveDog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GiveDog(Dog dog)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("TakeDog", "Attendance");
            }
            return View();
        }
    }
}
