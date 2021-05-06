using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DogShelter.Models
{
    public class Dog
    {
        public int ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DogPostDate { get; set; }
        public string Nickname { get; set; }
        public bool Male { get; set; }
        public int Age { get; set; }
        public string ShortDesc { get; set; }
        public string Desc { get; set; }
        public string ImgPath { get; set; }
    }
}
