using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogShelter.Models
{
    public class MoreAboutViewModel
    {
        public Dog DogPost { get; set; }
        public Dictionary<int, List<DateTime>> FreeDatetimes { get; set; }
        public DateSend DateToSend { get; set; }
    }
}
