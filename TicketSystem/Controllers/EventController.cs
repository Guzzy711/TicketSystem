using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data; 
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Helpers;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class EventController : Controller
    {
        DBhelper dbhelper = new DBhelper();


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]                                   //route
        public IActionResult CreateEvent(string name, string location, string date, string time, int ticketamount, int price, string image, string description)        //bedre måde at skrive det på men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {
               
                dbhelper.InsertQueryToDB($"INSERT INTO events(event_name, location, date, time, ticket_amount, price, image, description) VALUES ('{name}','{location}','{date}','{time}','{ticketamount}','{price}','{image}','{description}')");
                return RedirectToAction("OrganizerLandingPage", "Organizer");           //skal laves om til organizer home
            }
            return View();
        }

       
     
        [HttpPost]                                   //route
        public IActionResult EditEvent(string name, string location, string date, string time, int ticketamount, int price, string image, string description)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {


               
                dbhelper.InsertQueryToDB($"UPDATE events(event_name, location, date, time, ticket_amount, price, image, description) VALUES ('{name}','{location}','{date}','{time}','{ticketamount}','{price}','{image}','{description}')");
                return RedirectToAction("OrganizerLandingPage", "Organizer");           //skal laves om til organizer home
            }

            return View();
        }
        public IActionResult EditEvent()
        {
            return View();
        }
    }
}