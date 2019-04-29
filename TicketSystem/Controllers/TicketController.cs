using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicketSystem.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            var information = new Models.Ticket()
            {
                CustomerName = "Dronning Magrethe",
                TicketID = 123151,
            };

            ViewData["Ticket"] = information;

            return View();
        }
    }
}