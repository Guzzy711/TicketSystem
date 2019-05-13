using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.Helpers;
using System.Net.Mail;
using System.Net;
namespace TicketSystem.Models
{
    public class Event
    {
        DBhelper dBhelper = new DBhelper();

        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int TicketAmount { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool ActiveState { get; set; }
        public int TicketsSold { get; set; }
        public int TicketsLeft { get; set; }
        public int OrganizerID { get; set; }


        public Event() { }

        public Event(int event_id, string event_name, string location, DateTime date, TimeSpan time, int ticket_amount, float price, string image, string description, bool active_state, Int64 TicketsSold, int organizer_id)
        {
            EventID = event_id;
            EventName = event_name;
            Location = location;
            Date = date;
            Time = time;
            TicketAmount = ticket_amount;
            Price = price;
            Image = image;
            Description = description;
            ActiveState = active_state;
            this.TicketsSold = (int)TicketsSold;
            TicketsLeft = TicketAmount - this.TicketsSold;
            OrganizerID = organizer_id;

        }

        public async Task CancelMail(Event eventt)
        {
            var query = $"SELECT * FROM tickets WHERE event_id = {eventt.EventID}";
            //var ticket = dBhelper.CreateOneTicketObject(20196633); 
            var tickets = dBhelper.CreateTicketObjectsFromQuery(query);

            foreach (Ticket ticket in tickets)
            {
                var body = "<table align ='center' style=' border: 1px solid black;'><tr><td style='padding:10px;'><h1>Hello {0},</h1></td></tr><tr><td style='padding:10px;'><p>{1}</p></td></tr><tr><td style='padding:10px;'><p>{2}</p></td></tr><tr><td style='padding:10px;'>You are receiving this email because you bought a ticket on TicketSystem.</td></tr></table>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(ticket.CustomerEmail));  // replace with valid value 
                message.From = new MailAddress("info@guzzy.dk");  // replace with valid value
                message.Subject = $"Event Cancelled for {eventt.EventName} with TicketID #{ticket.TicketID}";
                message.Body = string.Format(body,ticket.CustomerFirstname, $"Unfortunately the event {eventt.EventName} has been cancelled.","You will recieve a refund within a couple of days.");
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
}
