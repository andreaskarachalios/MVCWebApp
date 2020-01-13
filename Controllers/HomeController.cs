using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;

namespace MyWebApp.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {
            var dates = Enumerable.Range(1, DateTime.DaysInMonth(2020, 2))  // Days: 1, 2 ... 31 etc.
            .Select(day => new DateTime(2020, 2, day)) // Map each day to a date
            .GroupBy(d => d.DayOfWeek)
            .ToArray();

            ViewData["content"] = dates;
            return View();
        }
    }
}