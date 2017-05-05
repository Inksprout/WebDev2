using System;
using System.Collections.Generic;

namespace CineplexWebsite.Models
{
    public partial class Cineplex
    {
        public Cineplex()
        {
            CineplexMovie = new HashSet<CineplexMovie>();
            MovieSession = new HashSet<MovieSession>();
        }

        public int CineplexId { get; set; }
        public string Location { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<CineplexMovie> CineplexMovie { get; set; }
        public virtual ICollection<MovieSession> MovieSession { get; set; }
    }
}
