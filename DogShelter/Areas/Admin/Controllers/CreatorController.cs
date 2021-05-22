using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogShelter.Models;
using DogShelter.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DogShelter.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CreatorController : Controller
    {
        private readonly AppDbContext DB;
        ILogger<CreatorController> log;
        IWebHostEnvironment HostEnvironment;

        public CreatorController(AppDbContext _DB, IWebHostEnvironment _hostEnvironment, ILogger<CreatorController> logger)
        {
            DB = _DB;
            HostEnvironment = _hostEnvironment;
            log = logger;
        }

        [HttpGet]
        public IActionResult NewPost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewPost(CreatePostModel newPostModel)
        {
            if (ModelState.IsValid)
            {
                if (newPostModel.Img11 != null)
                {
                    string uniqueFileName = Guid.NewGuid().ToString();
                    string fileExtension = Path.GetExtension(newPostModel.Img11.FileName);
                    newPostModel.NewPost.ImgPath  = "/img/" + uniqueFileName + fileExtension;
                    using (var fileStream = new FileStream(Path.Combine(HostEnvironment.WebRootPath + "/img/", uniqueFileName) + fileExtension, FileMode.Create))
                    {
                        await newPostModel.Img11.CopyToAsync(fileStream);
                    }
                    DB.News.Add(newPostModel.NewPost);
                    await DB.SaveChangesAsync();
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }

            }
            return View(newPostModel);
        }

        [HttpGet]
        public IActionResult DogPost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DogPost(DogPostModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = Guid.NewGuid().ToString();
                string fileExtension = Path.GetExtension(model.Img11.FileName);
                model.Dog.ImgPath = "/img/" + uniqueFileName + fileExtension;
                using (var fileStream = new FileStream(Path.Combine(HostEnvironment.WebRootPath + "/img/", uniqueFileName) + fileExtension, FileMode.Create))
                {
                    await model.Img11.CopyToAsync(fileStream);
                }
                model.Dog.DogPostDate = DateTime.Today;
                DB.DogPosts.Add(model.Dog);
                await DB.SaveChangesAsync();
                return RedirectToAction("TakeDog", "Service", new { area = "Admin" });
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(string postID)
        {
            News newToDelete = DB.News.Where(x => x.ID == Convert.ToInt32(postID)).FirstOrDefault();
            DB.News.Attach(newToDelete);
            DB.News.Remove(newToDelete);
            await DB.SaveChangesAsync();
            return RedirectToAction("Index", "Admin", new { area = "Admin"});
        }

        public async Task<IActionResult> DeleteDogPost(int ID)
        {
            Dog dogToDelete = DB.DogPosts.FirstOrDefault( x => x.ID == ID);
            DB.DogPosts.Attach(dogToDelete);
            DB.DogPosts.Remove(dogToDelete);
            await DB.SaveChangesAsync();
            return RedirectToAction("TakeDog", "Service", new { area = "Admin" });
        }

        public async Task<IActionResult> EditDogPost(int ID)
        {
            Dog dogToEdit = DB.DogPosts.FirstOrDefault(x => x.ID == ID);
            DB.DogPosts.Attach(dogToEdit);
            DB.DogPosts.Remove(dogToEdit);
            await DB.SaveChangesAsync();
            return RedirectToAction("DogPost", "Creator", new { area = "Admin", dog = dogToEdit });
        }
    }
}
