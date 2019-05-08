using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace TicketSystem.Models
{
    public class Customer
    {
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


        public Customer()
        {

        }
        public Customer(int EventID, string EventName, string Location, DateTime Date, TimeSpan Time, int TicketAmount, float Price, string Description, bool ActiveState)
        {
            this.EventID = EventID;
            this.EventName = EventName;
            this.Location = Location;
            this.Date = Date;
            this.Time = Time;
            this.TicketAmount = TicketAmount;
            this.Price = Price;
            this.Description = Description;
            this.ActiveState = ActiveState;

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
