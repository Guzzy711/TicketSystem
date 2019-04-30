using System;
namespace TicketSystem.Models
{
    public class Organizer
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    
    }
}
