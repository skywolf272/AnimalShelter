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
using DogShelter.Service;


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

        [HttpGet]
        public IActionResult ShelterDogsList()
        {
            return View(DB.DogPosts.ToList());
        }

        [HttpGet]
        public IActionResult Help()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TakeCare()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GiveDog()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MoreAboutDog(int ID)
        {
            MoreAboutViewModel viewModel = new MoreAboutViewModel();
            viewModel.DogPost = DB.DogPosts.FirstOrDefault(x => x.ID == ID);
            List<AppointmentToShelter> appointments = DB.Appointments.Where(x => x.DateTime > DateTime.Today).ToList();
            DateTime dateView = WeekStart.StartOfWeek(DateTime.Today, DayOfWeek.Monday);
            viewModel.FreeDatetimes = new Dictionary<int, List<DateTime>>();
            for (int day = 0; day < 7; day++)
            {
                viewModel.FreeDatetimes.Add(day, new List<DateTime>());
                for (int hour = 13; hour < 20; hour++)
                {
                    if (dateView.AddDays(day).AddHours(hour) >= DateTime.Now && appointments.FirstOrDefault(x => x.DateTime == dateView.AddDays(day).AddHours(hour)) == null)
                    {
                        viewModel.FreeDatetimes[day].Add(dateView.AddDays(day).AddHours(hour));
                    }
                }
            }

            if (viewModel.DogPost != null)
            {
                return View(viewModel);
            }
            return RedirectToAction("ShelterDogsList", "Service");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(string dateToSend, int ID)
        {
            AppointmentToShelter appointmentToSave = new AppointmentToShelter()
            {
                FirstName = "Admin",
                Tel = "Admin telephone",
                DateTime = Convert.ToDateTime(dateToSend)
            };
            DB.Appointments.Add(appointmentToSave);
            await DB.SaveChangesAsync();
            return RedirectToAction("ShelterDogsList");
        }
    }
}
