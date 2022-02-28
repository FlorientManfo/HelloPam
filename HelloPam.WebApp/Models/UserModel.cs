using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloPam.WebApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Fullname { get; set; }
        public DateTime CreatedAt { get; set; }
        public string StatusName { get => Status ? "Enable" : "Disable"; }
        public string Profile { get; set; }
        public string Picture { get; set; }
        public bool Status { get; set; }
        public int ProfileSelectedValue { get; set; }
        public IEnumerable<SelectListItem> Profiles { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public UserModel()
        {

        }

        public UserModel(int id, string username, string password, string confirmPassword, string fullname, DateTime createdAt, 
            bool status, string profile, string picture)
        {
            Id = id;
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
            Fullname = fullname;
            CreatedAt = createdAt;
            Status = status;
            Profile = profile;
            Picture = picture;
        }

        public UserModel(int id, string username, string password, string confirmPassword, string fullname, DateTime createdAt, 
            bool status, string profile, string picture, IEnumerable<SelectListItem> profiles) : 
            this(id, username, password, confirmPassword, fullname, createdAt, status, profile, picture)
        {
            Profiles = profiles;
        }
    }
}