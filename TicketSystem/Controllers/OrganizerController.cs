using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data; 
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Helpers;
using TicketSystem.Models;
using System.Web;



namespace TicketSystem.Controllers
{

    public class OrganizerController : Controller
    {
        Organizer organizer = new Organizer();
        DBhelper dbhelper = new DBhelper();



        public IActionResult Login()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                string queryString = $"SELECT * FROM Organizers WHERE EmailAddress='{email}' AND Password='{password}'";
                var result = dbhelper.SelectQuery(queryString);
                if (result.Rows.Count == 1)
                {
                   
                    return RedirectToAction("OrganizerLandingPage", "Organizer");
                              
                } else
                {
                    ViewBag.error = "Wrong username or password";
                }
               
                   
            }
         return View();
        }

            

        [HttpPost]                                   //route
        public IActionResult CreateOrganizer(string name, string password, string email, int phonenumber, string organizationName)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {
                dbhelper.InsertQueryToDB($"INSERT INTO Organizers(ContactPerson, Password, PhoneNumber, EmailAddress, OrganizationName) VALUES ('{name}','{password}','{phonenumber}','{email}','{organizationName}')");
                return RedirectToAction("Index", "Organizer");           //skal laves om til organizer home
            }

            return View();
        }



        [HttpPost]                                   //route
        public IActionResult EditEvent(string name, string location, string date, string time, int ticketamount, int price, string image, string description)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {



                dbhelper.InsertQueryToDB($"UPDATE Events (EventName, Location, Date, Time, TicketAmount, Price, Image, Description) VALUES ('{name}','{location}','{date}','{time}','{ticketamount}','{price}','{image}','{description}')");
                return RedirectToAction("Index", "Event");           //skal laves om til organizer home
            }

            return View();
        }
        public IActionResult EditEvent()
        {
            return View();
        }





        [HttpPost]                                   //route
        public IActionResult CreateEvent(int Organizer_ID,string name, string location, string date, string time, int ticketamount, int price, string image, string description)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {

                dbhelper.InsertQueryToDB($"INSERT INTO Events(Organizer_ID, EventName, Location, Date, Time, TicketAmount, Price, Image, Description) VALUES ('{Organizer_ID =10}','{name}','{location}','{date}','{time}','{ticketamount}','{price}','{image}','{description}')");
                return RedirectToAction("OrganizerLandingPage", "Organizer");           //skal laves om til organizer home
            }
            return View();

        }

        public IActionResult CreateEvent()
        {
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