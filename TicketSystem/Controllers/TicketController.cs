using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Helpers;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class TicketController : Controller
    {


        Ticket ticket = new Ticket();
        DBhelper dbhelper = new DBhelper();


        [HttpPost]                                   //route
        public IActionResult OrderTicket(string firstname, string surname, string email, int phonenumber)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {
              
                ticket.CustomerFirstname = firstname;
                ticket.CustomerSurname = surname;
                ticket.CustomerEmail = email;
                ticket.CustomerPhoneNumber = phonenumber;


                ViewBag.Message = ticket.CustomerFirstname;
                dbhelper.InsertQueryToDB($"INSERT INTO Tickets(CustomerFirstname, CustomerSurname, CustomerEmail, CustomerPhoneNumber) VALUES ('{ticket.CustomerFirstname}','{ticket.CustomerSurname}','{ticket.CustomerEmail}','{ticket.CustomerPhoneNumber}')");
                return RedirectToAction("Ïndex", "Ticket","Confirmation");           //skal laves om til organizer home
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









      
    
