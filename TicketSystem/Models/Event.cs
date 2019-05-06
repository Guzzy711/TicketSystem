using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class Event
    {
<<<<<<< HEAD

        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int TicketAmount { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }


=======
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int TicketAmount { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        //public DateTime (deadline)
        public bool ActiveState { get; set; }
>>>>>>> Database


        public Event(int EventID, string EventName, string Location, DateTime Date, TimeSpan Time, int TicketAmount, float Price, string Description, bool ActiveState)
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

    }
}
