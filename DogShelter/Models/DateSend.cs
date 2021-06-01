using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogShelter.Models
{
    public class DateSend
    {
        public DateTime DateToSend { get; set; }

        public DateSend(DateTime date)
        {
            DateToSend = date;
        }

        public DateSend()
        { 
        }
    }
}
