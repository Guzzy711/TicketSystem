using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using TicketSystem.Helpers; 

namespace TicketSystem.Models
{
    public class Ticket
    {
        public string CustomerFirstname { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public int CustomerPhoneNumber { get; set; }
        public int TicketID { get; set; }

        Random rand = new Random();
        DBhelper db = new DBhelper();

        public Ticket() { }

        public Ticket(string Firstname, string Surname, string Email, int PhoneNumber, int TicketID)
        {
            CustomerFirstname = Firstname;
            CustomerSurname = Surname;
            CustomerEmail = Email;
            CustomerPhoneNumber = PhoneNumber;
            this.TicketID = TicketID;  
        }


        public int IDGenerator()
        {
            int ID = 0; 

            List<int?> keyList = new List<int?>();

            var result = db.SelectQuery("SELECT id FROM tickets");

            foreach (DataRow row in result.Rows)
            {
                keyList.Add((int?)row["id"]);
            }

            do
            {
                string year = 2019.ToString(); 
                string randomValue = rand.Next(1000, 9999).ToString();

                ID = int.Parse(year+randomValue); //in order to get the format 2019XXXX 

            }
            while (keyList.Contains(ID));


            return ID; 
        }
        
    }
}
