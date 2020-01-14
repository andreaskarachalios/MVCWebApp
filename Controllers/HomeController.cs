using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;

namespace MyWebApp.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {

            return View();
        }
    }
}