using DogShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DogShelter.Data;

namespace DogShelter.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext DB;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext dbContext, ILogger<HomeController> logger)
        {
            DB = dbContext;
            _logger = logger;
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
            _logger.LogInformation(NewID.ToString());
            News currentNew = DB.News.Where(x => x.ID == NewID).FirstOrDefault();
            return View(currentNew);
        }
    }
}
