using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class Customer
    {
        public int event_id { get; set; }
        public string event_name { get; set; }
        public string location { get; set; }
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
        public int ticket_amount { get; set; }
        public float price { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public bool active_state { get; set; }



        public Customer(int event_id, string event_name, string location, DateTime date, TimeSpan time, int ticket_amount, float price, string description, bool active_state)
        {
            this.event_id = event_id;
            this.event_name = event_name;
            this.location = location;
            this.date = date;
            this.time = time;
            this.ticket_amount = ticket_amount;
            this.price = price;
            this.description = description;
            this.active_state = this.active_state;
        }

    }
}
