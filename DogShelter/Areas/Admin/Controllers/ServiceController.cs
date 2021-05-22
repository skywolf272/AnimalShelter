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

        [HttpGet]
        public IActionResult OverexposureList()
        {
            //DB.OverexposureDogs.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult ShelterDogsList()
        {
            return View(DB.DogPosts.ToList());
        }

        public IActionResult OrdersForShelter()
        {
            //DB.OrdersForShelter.ToList();
            return View();
        }
    }
}
