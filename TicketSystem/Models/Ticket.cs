using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using TicketSystem.Helpers;
using System.Net.Mail;
using System.Net;

namespace TicketSystem.Models
{
    public class Ticket
    {
        public string CustomerFirstname { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public int CustomerPhoneNumber { get; set; }
        public int TicketID { get; set; }
        public int EventID { get; set; }

        Random rand = new Random();
        DBhelper db = new DBhelper();

        public Ticket() { }

        public Ticket(string Firstname, string Surname, string Email, int PhoneNumber, int TicketID, int EventID)
        {
            CustomerFirstname = Firstname;
            CustomerSurname = Surname;
            CustomerEmail = Email;
            CustomerPhoneNumber = PhoneNumber;
            this.TicketID = TicketID;
            this.EventID = EventID; 
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

        public async Task SendTicketAsync()
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("Guzzy711@gmail.com"));  // replace with valid value 
            message.From = new MailAddress("info@guzzy.dk");  // replace with valid value
            message.Subject = "Your email subject";
            message.Body = string.Format(body, "Christian", "Guzzy711@gmail.com", "test");
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "info@guzzy.dk",  // replace with valid value
                    Password = "gomucanodi96"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "asmtp.unoeuro.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);

            }
        }

    }
}
