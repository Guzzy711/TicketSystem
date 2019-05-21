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
        public bool TicketUsed { get; set; }
        public DateTime DateOfPurchase { get; set; }

        Random rand = new Random();
        DBhelper db = new DBhelper();

        public Ticket() { }

        public Ticket(string Firstname, string Surname, string Email, int PhoneNumber, int TicketID, int EventID, bool TicketUsed, DateTime DateOfPurchase)
        {
            CustomerFirstname = Firstname;
            CustomerSurname = Surname;
            CustomerEmail = Email;
            CustomerPhoneNumber = PhoneNumber;
            this.TicketID = TicketID;
            this.EventID = EventID;
            this.TicketUsed = TicketUsed;
            this.DateOfPurchase = DateOfPurchase; 
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

        public async Task SendTicketAsync(Ticket ticket)
        {
            Event eventt = db.CreateOneEventObject(ticket.EventID);

            var body = "<table align ='center' style=' border: 1px solid black;'><tr><td style='padding:10px;'><h1>Hello {0},</h1></td> </tr><tr><td style='padding:10px;'><p>{1}</p></td></tr> <tr><td style='padding:10px;'><span>* Please show this at the event</span><h3>{2}</h3> <h3>{3}</h3><h3>{4}</h3> <h3>{5}</h3><h3>{6}</h3></td></tr><tr><td style='padding:10px;'>You are receiving this email because you bought a ticket on TicketSystem.</td></tr></table>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(ticket.CustomerEmail));  // replace with valid value 
            message.From = new MailAddress("info@guzzy.dk");  // replace with valid value
            message.Subject = $"Ticket Confirmation #{ticket.TicketID}";
            message.Body = string.Format(body, ticket.CustomerFirstname, $"Your recent order for {eventt.EventName} has been completed. " +
                "Your order details are shown below for reference:", $"Your TicketID: #{ticket.TicketID} (Date of Purchase:  { ticket.DateOfPurchase})",
                $"Your name: {ticket.CustomerFirstname} {ticket.CustomerSurname}", $"Ticket price: {eventt.Price},-",
                $"Event Location: {eventt.Location}",
                $"Event day: {eventt.Date} Time: {eventt.Time}");

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
