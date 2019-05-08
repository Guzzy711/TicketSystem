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
        public IActionResult OrderTicket(string customer_first_name, string customer_surname, string customer_email, int customer_phonenumber,int EventID)      
        {
            if (ModelState.IsValid)
            {

                dbhelper.InsertQueryToDB($"INSERT INTO tickets(event_id, customer_first_name, customer_surname, customer_email, customer_phone_number) VALUES ({EventID},'{customer_first_name}','{customer_surname}','{customer_email}',{customer_phonenumber})");
                return RedirectToAction("Confirmation", "Ticket");         
            }

            return View();
        }

        public IActionResult OrderTicket(int id)
        {


            ViewBag.Events = dbhelper.CreateEventObjectsFromQuery($"SELECT * FROM events WHERE id={id}");



            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
