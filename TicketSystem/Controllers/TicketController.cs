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


        Ticket ticket = new Ticket();
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
                ticket.CustomerFirstname = firstname;
                ticket.CustomerSurname = surname;
                ticket.CustomerEmail = email;
                ticket.CustomerPhonenumber = phonenumber;

        

                ViewBag.Message = ticket.CustomerFirstname;
                dbhelper.InsertQueryToDB($"INSERT INTO Tickets(CustomerFirstname, CustomerSurname, CustomerEmail, CustomerPhonenumber) VALUES ('{ticket.CustomerFirstname}','{ticket.CustomerSurname}','{ticket.CustomerEmail}','{ticket.CustomerPhonenumber}')");
                return RedirectToAction("OrganizerLandingPage", "Organizer");           //skal laves om til organizer home
            }

            return View();
        }

        public IActionResult OrderTicket()
        {
            return View();
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
   
}









      
    
