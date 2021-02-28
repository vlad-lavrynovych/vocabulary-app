using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vocabulary_app.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AckResponse()
        {
            //Password123@
            if (User.Identity.Name == "webadmin@example.com")
            {
                string username = User.Identity.Name;
                ViewBag.username = username;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Index()
        {
            return AckResponse();
        }

        public IActionResult AddTopic()
        {
            return AckResponse();
        }

        public IActionResult AddWord()
        {
            return AckResponse();
        }
    }
}
