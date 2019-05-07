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

        DBhelper dbhelper = new DBhelper();



        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            if (ModelState.IsValid)
            {
                string queryString = $"SELECT * FROM organizers WHERE email_address='{email}' AND password='{password}'";
                var result = dbhelper.SelectQuery(queryString);
                if (result.Rows.Count == 1)
                {
                    foreach(DataRow row in result.Rows)
                    {
                        return RedirectToAction("OrganizerLandingPage", new { id = (int)row["id"] });
                    }

                

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
                dbhelper.InsertQueryToDB($"INSERT INTO organizers(contact_person, password, phone_number, email_address,organization_name) VALUES ('{name}','{password}','{phonenumber}','{email}','{organizationName}')");
                return RedirectToAction("Index", "Organizer");           //skal laves om til organizer home
            }

            return View();
        }



        [HttpPost]                                   //route
        public IActionResult EditEvent(string name, string location, string date, string time, int ticketamount, int price, string image, string description)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {



                dbhelper.InsertQueryToDB($"UPDATE events (event_name, location, date, time, ticket_amount, price, image, description) VALUES ('{name}','{location}','{date}','{time}','{ticketamount}','{price}','{image}','{description}')");
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

                dbhelper.InsertQueryToDB($"INSERT INTO events(organizer_id, event_name, location, date, time, ticket_amount, price, image, description) VALUES ('{10}','{name}','{location}','{date}','{time}','{ticketamount}','{price}','{image}','{description}')");
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
            ViewBag.Organizer =  dbhelper.CreateOrganizerObject(1); 
            return View();
        }

        [HttpGet]
        public IActionResult OrganizerLandingPage(int ID)
        {
            ViewBag.Organizer = dbhelper.CreateOrganizerObject(ID);
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