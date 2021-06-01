using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "text")]
        public string Desc { get; set; }
        public string ImgPath { get; set; } = "";
        public DateTime NewsDate { get; set; } = DateTime.Today;
    }
}
