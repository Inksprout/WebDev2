using System;
using System.Collections.Generic;

namespace CineplexWebsite.Models
{
    public partial class MovieSession
    {
        public int CineplexId { get; set; }
        public int MovieId { get; set; }
        public int MovieSessionId { get; set; }
        public DateTime SessionTime { get; set; }

        public virtual Cineplex Cineplex { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
