using HelloPam.BO;
using HelloPam.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloPam.BLL
{
    public class UserBLO
    {
        private readonly UserDAO userDAO;
        public UserBLO()
        {
            userDAO = new UserDAO();
        }

        public void CreateUser(User user)
        {
            if(user == null)
                throw new ArgumentNullException("user");
            user.CreatedAt = DateTime.Now;
            if (user.Status == null)
                throw new ArgumentNullException("User status cannot be null !");
            if(user.Profile == null)
                throw new ArgumentNullException("User profile cannot be null !");
            userDAO.Add(user);
        }

        public void EditUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            user.CreatedAt = DateTime.Now;
            if (user.Status == null)
                throw new ArgumentNullException("User status cannot be null !");
            if (user.Profile == null)
                throw new ArgumentNullException("User profile cannot be null !");
            userDAO.Set(user);
        }

        public void DeleteUser(int id)
        {           
            userDAO.Delete(id);
        }

        public User GetUser(int id)
        {
            return userDAO.Get(id);
        }

        public User AuthenticateUser(string username, string password)
        {
            var user = userDAO.Login(username, password);
            if (user == null) return null;
            if (user.Status == false)
                throw new UnauthorizedAccessException("Your account is disabled !");
            return user;
        }

        public IEnumerable<User> FindUser(User user = null)
        {
            return userDAO.Find(user).OrderByDescending(x => x.CreatedAt).ToList();
        }
    }
}
