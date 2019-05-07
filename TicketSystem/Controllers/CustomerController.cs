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
        public IActionResult OrderTicket(string customer_firstname, string customer_surname, string customer_email, int customer_phonenumber,int event_id)      
        {
            if (ModelState.IsValid)
            {

                dbhelper.InsertQueryToDB($"INSERT INTO tickets(customer_first_name, customer_surname, customer_email, customer_phone_number, event_id) " +
                	"VALUES ('{customer_firstname}','{customer_surname}','{customer_email}',{customer_phonenumber},{event_id})");
                return RedirectToAction("LandingPage", "Customer");         
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
