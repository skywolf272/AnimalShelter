using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DogShelter.Models
{
    public class RegisterViewModel
    {
        [Required]
        string FirstName { get; set; }
        [Required]
        string SecondName { get; set; }
        [Required]
        string Login { get; set; }
        [Required]
        string Password { get; set; }
    }
}
