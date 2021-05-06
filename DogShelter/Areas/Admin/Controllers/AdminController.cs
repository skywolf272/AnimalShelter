using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogShelter.Models;
using DogShelter.Data;
using Microsoft.AspNetCore.Authorization;

namespace DogShelter.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext DB;

        public AdminController(AppDbContext _dbContext)
        {
            DB = _dbContext;
        }

        public IActionResult Index()
        {
            NewsViewModel viewModel = new NewsViewModel();
            viewModel.News = DB.News.ToList();
            viewModel.NewestDogs = DB.DogPosts.Take(3).ToList();
            return View(viewModel);
        }
    }
}
