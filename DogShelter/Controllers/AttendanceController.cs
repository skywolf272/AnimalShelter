using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DogShelter.Models;

namespace DogShelter.Views.Home
{
    public class AttendanceController : Controller
    {
        public IActionResult TakeCare()
        {
            return PartialView("TakeCare", new News { Title ="pivo"});
        }

        public IActionResult TakeDog()
        {
            List<Dog> dogs = new List<Dog>();
            dogs.Add(new Dog { Nickname = "Гниложоп", ImgPath = @"/img/ketchus.png", Age = 25, Male = true, ShortDesc = "Прекрасный, умелый, творческий, интеллегентый, невороятный", Desc = "Хороший, упрямый, Интересный, лучший, очаровательный"});
            dogs.Add(new Dog { Nickname = "Стозуб жевоглотный", ImgPath = @"/img/sax.png", Age = 66, Male = true, ShortDesc = "Очень дорбый и ласковый", Desc = "Никогда не ел людей" });
            dogs.Add(new Dog { Nickname = "Электропес", ImgPath = @"/img/sobaka.png", Age = 11, Male = true, ShortDesc = "Немного нервный", Desc = "В детсвте ударило электричеством" });
            dogs.Add(new Dog { Nickname = "Собака", ImgPath = @"/img/jopex.png", Age = 0, Male = false, ShortDesc = "Короткое описание", Desc = "Описание" });
            return View(dogs);
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
