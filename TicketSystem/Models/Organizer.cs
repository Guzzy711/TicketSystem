using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;




namespace TicketSystem.Models
{
    public class Organizer
    {

        public string ContactPerson { get; set; }


        public string Password { get; set; }


        public string PhoneNumber { get; set; }


        public string Email { get; set; }


        public string OrganizationName { get; set; }

        public int OrganizerID { get; set; }

        public Organizer()
        {

        }

        public Organizer(string ContactPerson, string Password, string PhoneNumber, string Email, string OrganizationName, int OrganizerID)
        {
            this.ContactPerson = ContactPerson;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.OrganizationName = OrganizationName;
            this.OrganizerID = OrganizerID; 
        }

    }


}
