using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogShelter.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DogShelter.Models
{
    public class EditDogPostModel
    {
        public Dog Dog { get; set; }
        public IFormFile Img11 { get; set; }
    }
}
