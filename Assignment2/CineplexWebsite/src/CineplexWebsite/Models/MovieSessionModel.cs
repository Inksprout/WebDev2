using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineplexWebsite.Models
{
    public class MovieSessionModel
    {
        public Guid SessionId { get; set; }
        public string MovieName { get; set; }
        public string CinemaName { get; set; }
        public string SessionTime { get; set; }
        public ICollection<SeatModel> Seats { get; set; }
    }
}
