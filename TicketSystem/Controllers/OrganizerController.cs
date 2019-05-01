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
    public class OrganizerController : Controller
    {
        Organizer organizer = new Organizer();
        DBhelper dbhelper = new DBhelper();

        public IActionResult Index()
        {
         return View();
        }

            

        [HttpPost]                                   //route
        public IActionResult CreateOrganizer(string name, string password, string email, int phonenumber, string organizationName)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {
                //InsertLogin(model.Name, model.Password);         //Mangler database
                organizer.Name = name;
                organizer.Password = password;
                organizer.Email = email;
                organizer.Phonenumber = phonenumber;
                organizer.OrganizationName = organizationName;

                ViewBag.Message = organizer.Name;
                dbhelper.InsertQueryToDB($"INSERT INTO Organizers(ContactPerson, Password, PhoneNumber, EmailAddress, OrganizationName) VALUES ('{organizer.Name}','{organizer.Password}','{organizer.Phonenumber}','{organizer.Email}','{organizer.OrganizationName}')");
                return RedirectToAction("Index", "Organizer");           //skal laves om til organizer home
            }

            return View();
        }



 



        public IActionResult CreateOrganizer()
        {
            return View();
        }

        public IActionResult OrganizerLandingPage()
        {
            return View();
        }

        public IActionResult OrganizerViewEvent()
        {
            return View();
        }
        public IActionResult ChangeLoginInfo()
        {
            return View();
        }
    }

}