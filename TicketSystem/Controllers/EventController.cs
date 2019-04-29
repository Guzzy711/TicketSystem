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
            var information = new Models.Event()
            {
                EventName = "BAIT/INF beerpong smashdown",
                Price = "200 kr",
                Location = "Heidi's",
                EventID = 1233291,
            };

            ViewData["Event"] = information;

            return View();
        }
    }
}