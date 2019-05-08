using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class Event
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
        public int TicketsSold { get; set; }
        public int TicketsLeft { get; set; }
        public int OrganizerID { get; set; }


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

    }
}
