using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogShelter.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DogShelter.Models
{
    public class CreatePostModel
    {
        public News NewPost { get; set; }
        [Required(ErrorMessage = "Фото обязательно")]
        public IFormFile Img11 { get; set; }
    }
}
