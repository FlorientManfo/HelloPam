using HelloPam.BLL;
using HelloPam.BO;
using HelloPam.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloPam.WebApp.Controllers
{
    public class UserController : Controller
    {
        private UserBLO userBLO;
        public UserController()
        {
            userBLO = new UserBLO();
        }
        // GET: User
        public ActionResult Index()
        {
            var users = userBLO.FindUser();
            var userModels = users?.Select
            (
                x =>
                new UserModel
                (
                    x.Id,
                    x.Username,
                    x.Password,
                    x.Password,
                    x.Fullname,
                    (DateTime)x.CreatedAt,
                    (bool)x.Status,
                    x.Profile.ToString(),
                    Url.Action("Picture", "User", new { id = x.Id })
                )
            ).ToList();
            return View(userModels);
        }

        public ActionResult Edit(int id)
        {
            var user = userBLO.GetUser(id);
            if (user == null)
                return HttpNotFound();

            var userModel = new UserModel
            (
                user.Id,
                user.Username,
                user.Password,
                user.Password,
                user.Fullname,
                (DateTime)user.CreatedAt,
                (bool)user.Status,
                user.Profile.ToString(),
                Url.Action("Picture", "User", new { id = user.Id }),
                GetUserProfiles((BO.User.ProfileOptions)user.Profile)
            );
            return View(userModel);
        }

        private List<SelectListItem> GetUserProfiles(User.ProfileOptions profile)
        {
            return Enum.GetValues(typeof(User.ProfileOptions)).Cast<int>().Select
            (
                x =>
                new SelectListItem
                {
                    Value = x.ToString(),
                    Text = ((BO.User.ProfileOptions)x).ToString(),
                    Selected = ((int)profile) == x
                }
            ).ToList();
        }

        public FileContentResult Picture(int id)
        {
            var user = userBLO.GetUser(id);
            if(user != null && user.Picture != null)
            {
               return File(user.Picture, "image/jpg");
            }
            return null;
        }
    }
}