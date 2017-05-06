using System.ComponentModel.DataAnnotations;


namespace CineplexWebsite.Models
{
    public class Event
    {
        [Required]
        public string senderName { get; set; }
        [Required, EmailAddress]
        public string senderEmail { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
