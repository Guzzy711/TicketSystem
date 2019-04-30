using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;




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
