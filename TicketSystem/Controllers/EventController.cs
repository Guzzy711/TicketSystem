using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Helpers;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    public class EventController : Controller
    {

        DBhelper dbhelper = new DBhelper();


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ViewEvent()
        {
            return View();
        }

       
    }
}