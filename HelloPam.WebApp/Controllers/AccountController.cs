using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloPam.WebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View("");
        }

        // GET: Account
        public ActionResult Login()
        {
            return RedirectToAction("Index");
            //return View("Index");
        }
    }
}