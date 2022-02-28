using HelloPam.BLL;
using HelloPam.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HelloPam.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserBLO userBLO;

        public AccountController()
        {
            this.userBLO = new UserBLO();
        }

        // GET: Account
        public ActionResult Index(string returnUrl = null)
        {
            var model = new LoginModel { ReturnUrl = returnUrl };
            return View(model);
        }


        // GET: Account
        public ActionResult Login()
        {
            return RedirectToAction("Index");
            //return View("Index");
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                var user = userBLO.AuthenticateUser(model.Username, model.Password);
                FormsAuthentication.SetAuthCookie(user.Username, model.RememberMe);
                if (!string.IsNullOrEmpty(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
                return RedirectToAction("Index", "Home");
            }
            catch (KeyNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occured.please try again later !");          
                Console.Error.WriteLine($"---> {ex.Message}");
            }
            return View("Index", model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}