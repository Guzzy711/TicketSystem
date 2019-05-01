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

        Event events = new Event();
        DBhelper dbhelper = new DBhelper();


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]                                   //route
        public IActionResult CreateEvent(string name, string location, DateTime date, DateTime time, int amount, int price, string image, string description)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {
                //InsertLogin(model.Name, model.Password);         //Mangler database
                events.Name = name;
                events.Location = location;
                events.Date = date;
                events.Time = time;
                events.TicketAmount = amount;
                events.Price = price;
                events.Image = image;
                events.Description = description;

                ViewBag.Message = events.Name;
                dbhelper.InsertQueryToDB($"INSERT INTO Events(EventName, Location, Date, Time, TicketAmount, Price, Image, Description) VALUES ('{events.Name}','{events.Location}','{events.Date}','{events.Time}','{events.TicketAmount}','{events.Price}','{events.Image}','{events.Description}')");
                return RedirectToAction("Index", "Event");           //skal laves om til organizer home
            }

            return View();
        }

        public IActionResult CreateEvent()
        {
            return View();
        }

        public IActionResult EditEvent()
        {
            return View();
        }
    }
}