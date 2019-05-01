using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data; 
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Helpers; 

namespace TicketSystem.Controllers
{
    public class EventController : Controller
    {


        public IActionResult Index()
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