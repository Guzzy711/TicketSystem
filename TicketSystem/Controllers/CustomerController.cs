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
            ViewBag.Events = dbhelper.CreateEventObjectsFromQuery("SELECT * FROM Events"); 

            return View();
        }

         [HttpPost]                                   //route
        public IActionResult OrderTicket(string CustomerFirstname, string CustomerSurname, string CustomerEmail, int CustomerPhonenumber,int EventID)      
        {
            if (ModelState.IsValid)
            {

                dbhelper.InsertQueryToDB($"INSERT INTO Tickets(CustomerFirstname, CustomerSurname, CustomerEmail, CustomerPhonenumber, EventID) VALUES ('{CustomerFirstname}','{CustomerSurname}','{CustomerEmail}','{CustomerPhonenumber}',{EventID})");
                return RedirectToAction("LandingPage", "Customer");         
            }

            return View();
        }

        public IActionResult OrderTicket(int id)
        {


            ViewBag.Events = dbhelper.CreateEventObjectsFromQuery($"SELECT * FROM Events WHERE EventID={id}");



            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
