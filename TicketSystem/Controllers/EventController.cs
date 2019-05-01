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
            string columns = "EventName, Location, Description"; 
            DataTable queryResult = dBhelper.SelectQuery($"SELECT {columns} FROM Events");

            string[,] events = new string[queryResult.Rows.Count,queryResult.Columns.Count];

            int rowCounter = 0;
            int columnCounter=0;

            foreach (DataRow row in queryResult.Rows)
            {
                columnCounter = 0; 
                foreach (DataColumn column in queryResult.Columns)
                {
                    events[rowCounter, columnCounter] = (string)row[column.ColumnName];
                    columnCounter++;
                }
                rowCounter++;
            }

          
            ViewBag.rows = rowCounter;
            ViewBag.cols = columnCounter;
           
            ViewBag.events = events;

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