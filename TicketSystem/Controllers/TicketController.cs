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
    public class TicketController : Controller
    {


        Ticket tick = new Ticket();
        DBhelper dbhelper = new DBhelper();


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]                                   //route
        public IActionResult OrderTicket(string firstname, string surname, string email, int phonenumber)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {


                dbhelper.InsertQueryToDB($"INSERT INTO tickets(customer_firstname, customer_surname, customer_email, customer_phonenumbe) VALUES ('{firstname}','{surname}','{email}','{phonenumber}')");
                return RedirectToAction("OrganizerLandingPage", "Organizer");           //skal laves om til organizer home
            }

            return View();
        }

        public IActionResult OrderTicket()
        {
            return View();
        }

    }
   
}









      
    
