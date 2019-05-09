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



        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                string queryString = $"SELECT * FROM organizers WHERE email_address='{email}' AND password='{password}'";
                var result = dbhelper.SelectQuery(queryString);
                if (result.Rows.Count == 1)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        return RedirectToAction("OrganizerLandingPage", new { id = (int)row["id"] });
                    }



                }
                else
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
                return RedirectToAction("Login", "Organizer");           //skal laves om til organizer home
            }

            return View();
        }



        [HttpGet]                                   //route
        public IActionResult DeleteOrganizer(int id)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {
                dbhelper.DeleteQuery($"DELETE FROM organizers WHERE id={id}");
                //dbhelper.DeleteQuery($"DELETE * FROM organizers WHERE id={id}");
               return RedirectToAction("Index", "Organizer");           //skal laves om til organizer home
            }

            return View();
        }
        public IActionResult DeleteOrganizer()
        {
            return View();
        }




        [HttpGet]                                   //route
        public IActionResult EditEvent(int id)// string name, string location, string date, string time, int ticketamount, int price, string image, string description)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {

                ViewBag.Events = dbhelper.CreateEventObjectsFromQuery($"SELECT * FROM events WHERE id={id}");

            }
            ViewBag.Organizer = dbhelper.CreateOrganizerObject(id);
            return View();
        }





        [HttpPost]
        public IActionResult EditEvent(int id, string name, string location, string date, string time, int ticketamount, int price, string image, string description)
        {
            if (ModelState.IsValid)
            {
                dbhelper.InsertQueryToDB($"UPDATE events SET event_name='{name}',location='{location}', date='{date}', time='{time}', ticket_amount={ticketamount}, price={price}, image='{image}', description='{description}' WHERE id={id}");
               
            }
            ViewBag.Organizer = dbhelper.CreateOrganizerObject(id);
            ViewBag.Events = dbhelper.CreateEventObjectsFromQuery($"SELECT * FROM events WHERE id={id}");

            return View();
        }







        [HttpPost]                                   //route
        public IActionResult CreateEvent(int id, string name, string location, string date, string time, int ticketamount, int price, string image, string description)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {

                dbhelper.InsertQueryToDB($"INSERT INTO events(organizer_id, event_name, location, date, time, ticket_amount, price, image, description) VALUES ('{id}','{name}','{location}','{date}','{time}','{ticketamount}','{price}','{image}','{description}')");
                return RedirectToAction("OrganizerLandingPage", new { id = (int)id });           //skal laves om til organizer home
            }
            return View();

        }

        public IActionResult CreateEvent(int id)
        {
            ViewBag.orgID = id;
            return View();
        }





        public IActionResult CreateOrganizer()
        {
            return View();
        }

        public IActionResult OrganizerLandingPage()
        {
            ViewBag.Organizer = dbhelper.CreateOrganizerObject(1);
            return View();
        }

        [HttpGet]
        public IActionResult OrganizerLandingPage(int ID)
        {
            ViewBag.Organizer = dbhelper.CreateOrganizerObject(ID);
            ViewBag.Events = dbhelper.CreateEventObjectsFromQuery($"SELECT * FROM events WHERE organizer_id = {ID}");

            return View();
        }

        public IActionResult OrganizerViewEvent(int ID)
        {

            ViewBag.Events = dbhelper.CreateEventObjectsFromQuery($"SELECT * FROM events WHERE id= {ID}");
            ViewBag.Tickets = dbhelper.CreateTicketObjectsFromQuery($"SELECT * FROM tickets WHERE event_id={ID}"); 

            return View();
        }



        [HttpGet]
        public IActionResult ChangeLoginInfo(int id)
        {
            if (ModelState.IsValid)
            {

                ViewBag.Organizer = dbhelper.CreateOrganizerObject(id);
            }
            ViewBag.Organizer = dbhelper.CreateOrganizerObject(id);
            return View();
        }
     

        [HttpPost]
        public IActionResult ChangeLoginInfo(int id, string organization_name, string contact_person, int phone_number, string email_address, string password)
        {
            if (ModelState.IsValid)
            {
                dbhelper.InsertQueryToDB($"UPDATE events SET organization_name='{organization_name}',contact_person='{contact_person}', phone_number={phone_number}, email_address='{email_address}', password='{password}' WHERE id={id}");
            }
            ViewBag.Organizer = dbhelper.CreateOrganizerObject(id);

            return View();
        }

    }

    }