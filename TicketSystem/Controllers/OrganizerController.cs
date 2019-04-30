using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Controllers
{
    public class OrganizerController : Controller
    {

        [HttpGet]   //httpget er dog default value
        public IActionResult Index()
        {


            return View();
        }

        [HttpPost]                                   //route
        public IActionResult Index(string name, string password)        //bedre måde at skrive de tpå men fungere ikke:Index(OrganizerModel model
        {
            if (ModelState.IsValid)
            {
               //InsertLogin(model.Name, model.Password);         //Mangler database

                return RedirectToAction("Index", "Home");           //skal laves om til organizer home
            }

            return View();
        }



        private void InsertLoginInformatin(string name, string password)
        {

        }




        public IActionResult CreateOrganizer()
        {


            return View();
        }
    }

}