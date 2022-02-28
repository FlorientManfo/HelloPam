using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloPam.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        //[AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}