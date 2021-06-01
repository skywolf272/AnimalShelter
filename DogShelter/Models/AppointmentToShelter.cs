using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DogShelter.Models
{
    public class AppointmentToShelter
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Tel { get; set; }
        public DateTime DateTime { get; set; }
        public int DogID { get; set; }
    }
}
