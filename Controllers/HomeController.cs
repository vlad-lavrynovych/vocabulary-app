using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using vocabulary_app.Models;

namespace vocabulary_app.Controllers
{

    //Application includes a controller named HomeController. HomeController has few methods. Any public method in a controller is exposed as a controller action.
    public class HomeController : Controller
    {
        //We can use ILogger or ILoggerFactory anywhere in an application using ASP.NET Core DI (Dependency Injection)
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //ILogger instance, which can be used to log in the Index() and Privacy() and Error() action methods.
        public IActionResult Index()
        {
            string username = User.Identity.Name;
            ViewBag.gretting = "Hello" + username;
            ViewBag.username = username;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}