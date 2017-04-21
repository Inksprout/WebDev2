using System;
using System.Collections.Generic;

namespace CineplexWebsite.Models
{
    public partial class MovieComingSoon
    {
        public int MovieComingSoonId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}
