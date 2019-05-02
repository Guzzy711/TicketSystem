using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Helpers; 

namespace TicketSystem.Controllers
{
    public class EventController : Controller
    {
        DBhelper dBhelper = new DBhelper(); 

        public IActionResult Index()
        {
            ViewBag.Events = dBhelper.CreateEventObjectsFromQuery(); 

            return View();
        }

        public IActionResult ViewEvent()
        {
            return View();
        }

        public IActionResult CreateEvent()
        {
            return View();
        }

        public IActionResult EditEvent()
        {
            return View();
        }
    }
}