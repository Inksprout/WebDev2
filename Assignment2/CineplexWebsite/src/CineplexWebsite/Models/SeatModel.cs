using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineplexWebsite.Models
{
    public class SeatModel
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string Price { get; set; }
        public string SeatType { get; set; }
    }
}
