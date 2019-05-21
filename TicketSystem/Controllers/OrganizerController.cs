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
        Ticket tick = new Ticket();
        Event evt = new Event();
        Organizer organizer = new Organizer();


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
                string queryString = $"SELECT * FROM organizers WHERE email_address='{email}' AND password='{password}'";
                var result = dbhelper.SelectQuery(queryString);
                foreach (DataRow row in result.Rows)
                {
                    return RedirectToAction("OrganizerLandingPage", new { id = (int)row["id"] });
                }
                //return RedirectToAction("OrganizerLandingPage", "Organizer");           //skal laves om til organizer home
            }

            return View();
        }



        [HttpGet]                                   
        public IActionResult DeleteOrganizer(int id)        
        {
            if (ModelState.IsValid)
            {
                dbhelper.DeleteQuery($"DELETE FROM organizers WHERE id={id}");
                //dbhelper.DeleteQuery($"DELETE * FROM organizers WHERE id={id}");
               return RedirectToAction("Login", "Organizer");           //skal laves om til organizer home
            }

            return View();
        }
        public IActionResult DeleteOrganizer()
        {
            return View();
        }


        [HttpGet]                                  
        public IActionResult CancelEvent(int id)
        {
            if (ModelState.IsValid)
            {
                dbhelper.InsertQueryToDB($"UPDATE events SET active_state='{0}' WHERE id={id}");
                var eventt = dbhelper.CreateOneEventObject(id);
                _ = evt.CancelMail(eventt);
                return RedirectToAction("OrganizerLandingPage", new { id = eventt.OrganizerID });

            }
                return View();
        }

        [HttpGet]                                   
        public IActionResult ReactivateEvent(int id)
        {
            if (ModelState.IsValid)
            {
                dbhelper.InsertQueryToDB($"UPDATE events SET active_state='{1}' WHERE id={id}");

                var eventt = dbhelper.CreateOneEventObject(id);
                
                return RedirectToAction("OrganizerLandingPage", new { id=eventt.OrganizerID});
            }

            return View();
        }

        [HttpGet]
        public IActionResult DeleteEvent(int id)
        {
            if (ModelState.IsValid)
            {
                var eventt = dbhelper.CreateOneEventObject(id);
                dbhelper.DeleteQuery($"DELETE FROM events WHERE id={id}");
               
                return RedirectToAction("OrganizerLandingPage", new { id = eventt.OrganizerID});        
            }

            return View();
        }
        public IActionResult DeleteEvent()
        {
            return View();
        }



        [HttpGet]
        public IActionResult TicketUsed(int id)
        {
            if (ModelState.IsValid)
            {
                var ticket = dbhelper.CreateOneTicketObject(id);
                var eventt = dbhelper.CreateOneEventObject(ticket.EventID);
                ViewBag.Organizer = dbhelper.CreateOrganizerObject(eventt.OrganizerID);
                dbhelper.InsertQueryToDB($"UPDATE tickets SET ticket_used='{1}' WHERE id={id}");
                TempData["success"]= $"Ticket (ID #{ticket.TicketID}) succesfully checked";
                return RedirectToAction("CheckTickets", new { id = eventt.EventID });
            }

            return View();
        }

        






        [HttpGet]                                 
        public IActionResult EditEvent(int id)
        {
            if (ModelState.IsValid)
            {
                var eventt = dbhelper.CreateOneEventObject(id);
                var organizerID = eventt.OrganizerID; 
                ViewBag.Event = eventt; 
                ViewBag.Organizer = dbhelper.CreateOrganizerObject(organizerID);
            }

            return View();
        }

        [HttpPost]
        public IActionResult EditEvent(int id, string name, string location, string date, string time, int ticketamount, int price, string image, string description)
        {
            if (ModelState.IsValid)
            {
                dbhelper.InsertQueryToDB($"UPDATE events SET event_name='{name}',location='{location}', date='{date}', time='{time}', ticket_amount={ticketamount}, price={price}, image='{image}', description='{description}' WHERE id={id}");

                var eventt = dbhelper.CreateOneEventObject(id);

                ViewBag.Event = eventt;
                ViewBag.Organizer = dbhelper.CreateOrganizerObject(eventt.OrganizerID);
                ViewBag.success = "Changes saved succesfully!";
            }

            return View();
        }



        public IActionResult ResendTicket(int id)
        {
            ViewBag.currentTicket = dbhelper.CreateOneTicketObject(id);
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
            ViewBag.Organizer = dbhelper.CreateOrganizerObject(id);
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

            var eventt = dbhelper.CreateOneEventObject(ID);
            ViewBag.Event = eventt; 
            ViewBag.Tickets = dbhelper.CreateTicketObjectsFromQuery($"SELECT * FROM tickets WHERE event_id={ID}");
            ViewBag.Organizer = dbhelper.CreateOrganizerObject(eventt.OrganizerID); 

            return View();
        }
        [HttpPost]
        public IActionResult OrganizerViewEvent(int ID, int ticketid, string Email) {
            var eventt = dbhelper.CreateOneEventObject(ID);
            ViewBag.Event = eventt;
            ViewBag.Tickets = dbhelper.CreateTicketObjectsFromQuery($"SELECT * FROM tickets WHERE event_id={ID}");
            var ticket = dbhelper.CreateOneTicketObject(ticketid);
            ticket.CustomerEmail = Email;
            ViewBag.Success = "The email has been successfully sent to " + ticket.CustomerEmail;
            ticket.CustomerEmail = Email; 
            _=tick.SendTicketAsync(ticket);
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
        public IActionResult ChangeLoginInfo(int id, string OrganizationName, string ContactPerson, int Phonenumber, string Email, string Password)
        {
            if (ModelState.IsValid)
            {
                dbhelper.InsertQueryToDB($"UPDATE organizers SET organization_name='{OrganizationName}',contact_person='{ContactPerson}', phone_number={Phonenumber}, email_address='{Email}', password='{Password}' WHERE id={id}");
            }
            ViewBag.Organizer = dbhelper.CreateOrganizerObject(id);
            ViewBag.success = "Changes saved succesfully!";
            return View();
        }

        public IActionResult CheckTickets(int id, int value) //id is EventID, value is TicketID!
        {
            if (ModelState.IsValid) {

                var ticket = dbhelper.CheckTicket(value,id); //eventID + ticketid
                var eventt = dbhelper.CreateOneEventObject(id);
                ViewBag.Organizer = dbhelper.CreateOrganizerObject(eventt.OrganizerID);
                ViewBag.Ticket = ticket; 

            }

            return View();
        }

        [HttpPost]
        public IActionResult CheckTickets(int id, int value, int ticket_id) //id is EventID, value is TicketID!
        {
            if (ModelState.IsValid)
            {

                var ticket = dbhelper.CheckTicket(ticket_id,id);
                var eventt = dbhelper.CreateOneEventObject(id);
                ViewBag.Organizer = dbhelper.CreateOrganizerObject(eventt.OrganizerID);
                ViewBag.Ticket = ticket;

            }

            return View();
        }


    }

}