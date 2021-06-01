using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DogShelter.Models;
using DogShelter.Data;
using DogShelter.Service;

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

        public IActionResult GiveDog()
        {
            return View();
        }

        //Список всех питомцев
        public IActionResult TakeDog()
        {
            return View(DB.DogPosts.ToList());
        }

        public IActionResult MoreAboutDog(int? ID)
        {
            MoreAboutViewModel viewModel = new MoreAboutViewModel();
            viewModel.DogPost = DB.DogPosts.FirstOrDefault(x => x.ID == ID);
            List<AppointmentToShelter> appointments = DB.Appointments.Where( x => x.DateTime > DateTime.Today && x.DogID == ID).ToList();
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
            return RedirectToAction("TakeDog", "Attendance");
        }

        [HttpPost]
        public IActionResult SignUp(string dateToSend, int ID)
        {
            SignUpViewModel viewModel = new SignUpViewModel();
            viewModel.Appointment = new AppointmentToShelter()
            {
                DogID = ID
            };
            viewModel.Date = Convert.ToDateTime(dateToSend);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SingUpSave(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                DB.Appointments.Add(model.Appointment);
                await DB.SaveChangesAsync();
                return RedirectToAction("TakeDog", "Attendance");
            }
            return RedirectToAction("SingUpSave","Attendance", new { model = model });
        }

        [HttpGet]
        public IActionResult Help()
        {
            return View();
        }
    }
}
