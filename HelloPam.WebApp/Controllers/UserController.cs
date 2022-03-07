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
        public ActionResult Index(string value)
        {
            User user = null;
            if(!string.IsNullOrEmpty(value))
            {
                user = new User { Username = value, Fullname = value };
            }
            var users = userBLO.FindUser(user);
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
                    x.Picture != null ? Url.Action("Picture", "User", new { id = x.Id }) : null
                )
            ).ToList();
            return View(userModels);
        }

        public ActionResult Create()
        {
            var userModel = new UserModel
            {
               Status = true,
               ProfileSelectedValue = (int)BO.User.ProfileOptions.Visitor,
               Profiles =  GetUserProfiles()
            };
            return View("Edit", userModel);
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            byte[] picture = null;
            if (model.Image != null && model.Image.ContentLength > 0)
            {
                picture = new byte[model.Image.ContentLength];
                model.Image.InputStream.Read(picture, 0, model.Image.ContentLength);
            }
            var user = new User
            (
                0,
                model.Username,
                model.Password,
                model.Fullname,
                (BO.User.ProfileOptions)model.ProfileSelectedValue,
                model.Status,
                picture,
                DateTime.Now
            );
            userBLO.CreateUser(user);
            return RedirectToAction("Create");
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
                user.Picture != null ? Url.Action("Picture", "User", new { id = user.Id }) : null,
                (int)user.Profile,
                GetUserProfiles()
            ) ;
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, UserModel model)
        {
            var user = userBLO.GetUser(id);
            if (user == null)
                return HttpNotFound();
            byte[] picture = null;
            if(model.Image != null && model.Image.ContentLength > 0)
            {
                picture = new byte[model.Image.ContentLength];
                model.Image.InputStream.Read(picture, 0, model.Image.ContentLength);
            }
            else
            {
                picture = user.Picture;
            }
            user = new User
            (
                id,
                model.Username,
                model.Password,
                model.Fullname,
                (BO.User.ProfileOptions)model.ProfileSelectedValue,
                model.Status,
                picture,
                (DateTime)user.CreatedAt
            );
            userBLO.EditUser(user);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
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
                user.Picture != null ? Url.Action("Picture", "User", new { id = user.Id }) : null
            );
            return View(userModel);
        }

        public ActionResult Delete(int id)
        {
            userBLO.DeleteUser(id);
            return RedirectToAction("Index");
        }

        private IEnumerable<SelectListItem> GetUserProfiles(User.ProfileOptions[] selectedProfiles = null)
        {
            return Enum.GetValues(typeof(User.ProfileOptions)).Cast<int>().Select
            (
                x =>
                new SelectListItem
                {
                    Value = x.ToString(),
                    Text = ((BO.User.ProfileOptions)x).ToString(),
                    Selected = selectedProfiles?.Contains((BO.User.ProfileOptions)x) ?? false
                }
            ).ToArray();
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