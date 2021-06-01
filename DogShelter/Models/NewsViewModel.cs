using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogShelter.Models;

namespace DogShelter.Models
{
    public class NewsViewModel
    {
        public List<News> News { get; set; }
        public List<Dog> NewestDogs { get; set; }
    }
}
