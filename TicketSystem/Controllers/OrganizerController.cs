using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicketSystem.Controllers
{
    public class OrganizerController : Controller
    {
        public IActionResult Index()
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
    }

}