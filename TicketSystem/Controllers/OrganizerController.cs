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
            var query = dbhelper.SelectQuery("SELECT * FROM Organizers");

            string s = ""; 

            foreach (DataRow row in query.Rows)
            {
                s += row["OrganizationName"]; 
            }

            Organizer organizer = new Organizer
            {
                Name = s
            };


            ViewBag.Message = organizer.Name; 

            return View();
        }

        [HttpPost]                                   //route
        public IActionResult CreateOrganizer(string name, string password)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {
                //InsertLogin(model.Name, model.Password);         //Mangler database
                organizer.Name = name;
                organizer.Password = password;
                ViewBag.Message = organizer.Name;
                dbhelper.InsertQueryToDB($"INSERT INTO Organizers(ContactPerson, Password) VALUES ('{organizer.Name}','{organizer.Password}')");
                return RedirectToAction("Index", "Organizer");           //skal laves om til organizer home
            }

            return View();
        }



        private void InsertLoginInformatin(string name, string password)
        {

        }




        public IActionResult CreateOrganizer()
        {


            return View();
        }
    }

}