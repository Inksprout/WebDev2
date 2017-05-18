using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineplexWebsite.Models
{
    public class MovieSessionDetailViewModel
    {
        public MovieSession MovieSession { get; set; }
        public Cineplex Cineplex { get; set; }
        public Movie Movie { get; set; }
    }
}
