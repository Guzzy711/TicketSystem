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
            ViewBag.Events = dbhelper.CreateEventObjectsFromQuery(); 

            return View();
        }

         [HttpPost]                                   //route
        public IActionResult OrderTicket(string CustomerFirstname, string CustomerSurname, string CustomerEmail, int CustomerPhonenumber)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {

                dbhelper.InsertQueryToDB($"INSERT INTO Tickets(CustomerFirstname, CustomerSurname, CustomerEmail, CustomerPhonenumber) VALUES ('{CustomerFirstname}','{CustomerSurname}','{CustomerEmail}','{CustomerPhonenumber}')");
                return RedirectToAction("LandingPage", "Customer");           //skal laves om til organizer home
            }

            return View();
        }

        public IActionResult OrderTicket()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
