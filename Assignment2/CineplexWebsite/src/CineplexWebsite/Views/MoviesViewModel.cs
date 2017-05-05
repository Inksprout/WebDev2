using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineplexWebsite.Models
{
    public class MoviesViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<MovieComingSoon> MoviesComingSoon { get; set; }
    }
}
