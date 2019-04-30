using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}