using System;
using System.Collections.Generic;

namespace CineplexWebsite.Models
{
    public partial class Enquiry
    {
        public int EnquiryId { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
