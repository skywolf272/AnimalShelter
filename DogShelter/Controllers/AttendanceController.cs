using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DogShelter.Models;
using DogShelter.Data;

namespace DogShelter.Views.Home
{
    public class AttendanceController : Controller
    {
        private readonly AppDbContext DB;

        public AttendanceController(AppDbContext _db)
        {
            DB = _db;
        }


        public IActionResult TakeCare()
        {
            return PartialView("TakeCare", new News { Title = "pivo" });
        }

        //Список всех питомцев
        public IActionResult TakeDog()
        {
            return View(DB.DogPosts.ToList());
        }

        public IActionResult MoreAboutDog(int ID)
        {
            Dog dog = DB.DogPosts.FirstOrDefault(x => x.ID == ID);
            if (dog != null)
            {
                return View(dog);
            }
            return RedirectToAction("TakeDog", "Attendance");
        }
    }
}
