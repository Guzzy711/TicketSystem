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
                ticket.Customer_firstname = firstname;
                ticket.Customer_surname = surname;
                ticket.Customer_email = email;
                ticket.Customer_phonenumber = phonenumber;
                   
                ViewBag.Message = ticket.Customer_firstname;
                dbhelper.InsertQueryToDB($"INSERT INTO tickets(customer_firstname, customer_surname, customer_email, customer_phonenumber) VALUES ('{ticket.Customer_firstname}','{ticket.Customer_surname}','{ticket.Customer_email}','{ticket.Customer_phonenumber}')");
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









      
    
