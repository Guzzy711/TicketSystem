using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models;
using TicketSystem.Helpers;
namespace TicketSystem.Controllers
{
   public class CustomerController : Controller
    {
        DBhelper dbhelper = new DBhelper();
        Ticket tick = new Ticket();
          
   
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LandingPage()
        {
            ViewBag.Events = dbhelper.CreateEventObjectsFromQuery("SELECT * FROM events"); 

            return View();
        }

         [HttpPost]                                   //route
        public IActionResult OrderTicket(string customer_first_name, string customer_surname, string customer_email, int customer_phonenumber,int id)      
        {
            if (ModelState.IsValid)
            {
                int ID = tick.IDGenerator();
                ViewBag.Events = dbhelper.CreateEventObjectsFromQuery($"SELECT * FROM events WHERE id={id}");
                dbhelper.InsertQueryToDB($"INSERT INTO tickets(id, event_id, customer_first_name, customer_surname, customer_email, customer_phone_number) VALUES ('{ID}','{id}','{customer_first_name}','{customer_surname}','{customer_email}',{customer_phonenumber})");
                return RedirectToAction("Confirmation", new {id = ID});     
            }

            return View();
        }

        public IActionResult OrderTicket(int id)
        {

            ViewBag.Events = dbhelper.CreateEventObjectsFromQuery($"SELECT * FROM events WHERE id={id}");

            return View();
        }

        public IActionResult Confirmation(int id)
        {
            if (ModelState.IsValid) {
                var ticket = dbhelper.CreateOneTicketObject(id);

                ViewBag.Event = dbhelper.CreateOneEventObject(ticket.EventID);

                ViewBag.Ticket = ticket; 

            }
           
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
