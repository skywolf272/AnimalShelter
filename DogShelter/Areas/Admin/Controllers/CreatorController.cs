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
using Microsoft.EntityFrameworkCore;

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
                return RedirectToAction("ShelterDogsList", "Service", new { area = "Admin" });
            }
            return View(model);
        }

        public async Task<IActionResult> DeletePost(string ID)
        {
            News newToDelete = DB.News.FirstOrDefault(x => x.ID == Convert.ToInt32(ID));
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
            return RedirectToAction("ShelterDogsList", "Service", new { area = "Admin" });
        }

        public async Task<IActionResult> EditDogPost(int ID)
        {
            Dog dogToEdit = DB.DogPosts.FirstOrDefault(x => x.ID == ID);
            DB.DogPosts.Attach(dogToEdit);
            DB.DogPosts.Remove(dogToEdit);
            await DB.SaveChangesAsync();
            return RedirectToAction("DogPost", "Creator", new { area = "Admin", dog = dogToEdit });
        }

        [HttpGet]
        public IActionResult Records()
        {
            return View(DB.Appointments.Where( x => x.DateTime > DateTime.Today).OrderBy( x => x.DateTime).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRecord(int ID)
        {
            var recordToDelete = DB.Appointments.FirstOrDefault( x => x.ID == ID);
            if (recordToDelete != null)
            {
                DB.Appointments.Remove(recordToDelete);
                await DB.SaveChangesAsync();
            }
            return RedirectToAction("Records", "Creator", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> EditDogPost(int? ID)
        {
            EditDogPostModel model = new EditDogPostModel();
            model.Dog = await DB.DogPosts.FirstOrDefaultAsync(x => x.ID == ID);
            if (model.Dog != null)
            {
                return View(model);
            }
            return RedirectToAction("ShelterDogsList", "Service");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDogPost(EditDogPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Img11 != null)
            {
                string uniqueFileName = Guid.NewGuid().ToString();
                string fileExtension = Path.GetExtension(model.Img11.FileName);
                model.Dog.ImgPath = "/img/" + uniqueFileName + fileExtension;
                using (var fileStream = new FileStream(Path.Combine(HostEnvironment.WebRootPath + "/img/", uniqueFileName) + fileExtension, FileMode.Create))
                {
                    await model.Img11.CopyToAsync(fileStream);
                }
            }

            if (model.Dog.DogPostDate == null)
            {
                model.Dog.DogPostDate = DateTime.Today;
            }
            DB.DogPosts.Update(model.Dog);
            await DB.SaveChangesAsync();
            return RedirectToAction("MoreAboutDog", "Service", new { ID = model.Dog.ID });
        }

        [HttpGet]
        public async Task<IActionResult> EditNewPost(int? ID)
        {
            EditNewViewModel model = new EditNewViewModel();
            model.EditNew = await DB.News.FirstOrDefaultAsync( x => x.ID == ID);
            if (model.EditNew != null)
            {
                return View(model);
            }
            return RedirectToAction("Index","Admin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNewPost(EditNewViewModel model)
        {
            if ( !ModelState.IsValid )
            {
                return View(model);
            }

            News newToUpdate = model.EditNew;
            if ( model.Img != null )
            {
                string uniqueFileName = Guid.NewGuid().ToString();
                string fileExtension = Path.GetExtension(model.Img.FileName);
                model.EditNew.ImgPath = "/img/" + uniqueFileName + fileExtension;
                using (var fileStream = new FileStream(Path.Combine(HostEnvironment.WebRootPath + "/img/", uniqueFileName) + fileExtension, FileMode.Create))
                {
                    await model.Img.CopyToAsync(fileStream);
                }
            }
            DB.News.Update(model.EditNew);
            await DB.SaveChangesAsync();
            return RedirectToAction("CurrentNew", "Admin", new { ID = newToUpdate.ID });
        }
    }
}
