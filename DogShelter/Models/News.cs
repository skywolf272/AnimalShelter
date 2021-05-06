using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DogShelter.Models
{
    public class News
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Необохдимо название")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Необохдимо краткое описание")]
        public string ShortDesc { get; set; }
        [Required(ErrorMessage = "Необохдимо описание")]
        public string Desc { get; set; }
        public string ImgPath { get; set; } = "";
        public DateTime NewsDate { get; set; } = DateTime.Today;
    }
}
