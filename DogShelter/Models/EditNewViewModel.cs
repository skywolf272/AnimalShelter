using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogShelter.Models
{
    public class EditNewViewModel
    {
        public News EditNew { get; set; }
        public IFormFile Img { get; set; }
    }
}
