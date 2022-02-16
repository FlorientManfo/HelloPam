using HelloPam.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace HelloPam.DAL
{
    public class UserDAO
    {
        private readonly Sql sql;
        public UserDAO()
        {
            sql = new Sql("HelloPam");
        }

        public void Add(User user)
        {
            sql.Execute
            (
                "Sp_User_Insert",
                GetParameters(user),
                true
            );
        }

        public void Add()
        {
            sql.Execute
            (
                "Sp_User_Default",
                GetParameters(null),
                true
            );
        }
        public void Set(User user)
        {
            sql.Execute
            (
                "Sp_User_Update",
                GetParameters(user),
                true
            );
        }

        public User Get(int id)
        {
            var reader = sql.Read
            (
                "Sp_User_Select",
                GetParameters(new User { Id = id }),
                true
            );

            while (reader.Read())
                return GetObject(reader);
            reader.Close();

            return null;
        }

        public User Login(string username, string password)
        {
            var reader = sql.Read
            (
                "Sp_User_Login",
                GetParameters(new User { Username = username, Password = password }),
                true
            );

            while (reader.Read())
                return GetObject(reader);
            reader.Close();

            return null;
        }

        public IEnumerable<User> Find(User user = null)
        {
            var reader = sql.Read
            (
                "Sp_User_Select",
                GetParameters(user),
                true
            );

            var users = new List<User>();
            while (reader.Read())
                users.Add(GetObject(reader));
            reader.Close();

            return users;
        }

        public void Delete(int id)
        {
            sql.Execute
            (
                "Sp_User_Delete",
                GetParameters(new User { Id = id }),
                true
            );
        }


        private User GetObject(DbDataReader reader)
        {
            return new User
            (
                reader["Id"] == DBNull.Value ? 0 : int.Parse(reader["Id"].ToString()),
                reader["Username"] == DBNull.Value ? null : reader["Username"].ToString(),
                reader["Password"] == DBNull.Value ? null : reader["Password"].ToString(),
                reader["Fullname"] == DBNull.Value ? null : reader["Fullname"].ToString(),
                reader["Profile"] == DBNull.Value ? User.ProfileOptions.Visitor : (User.ProfileOptions)int.Parse(reader["Profile"].ToString()),
                reader["Status"] == DBNull.Value ? false : bool.Parse(reader["Status"].ToString()),
                reader["Picture"] == DBNull.Value ? null : (byte[])reader["Picture"],
                reader["CreatedAt"] == DBNull.Value ? null : (DateTime?)DateTime.Parse(reader["CreatedAt"].ToString())
            );
           
        }

        private IEnumerable<Sql.Parameter> GetParameters(User user)
        {
            return new Sql.Parameter[]
            {
                new Sql.Parameter("@Id", DbType.Int32, (user == null || user.Id == 0 ? (object)DBNull.Value : user.Id)),
                new Sql.Parameter("@Username", DbType.String, (user == null || string.IsNullOrEmpty(user.Username) ? (object)DBNull.Value : user.Username)),
                new Sql.Parameter("@Password", DbType.String, (user == null || string.IsNullOrEmpty(user.Password) ? (object)DBNull.Value : user.Password)),
                new Sql.Parameter("@Fullname", DbType.String, (user == null || string.IsNullOrEmpty(user.Fullname) ? (object)DBNull.Value : user.Fullname)),
                new Sql.Parameter("@Profile", DbType.Int32, (user == null || user.Profile == null ? (object)DBNull.Value : (int)user.Profile)),
                new Sql.Parameter("@Status", DbType.Boolean, (user == null || user.Status == null ? (object)DBNull.Value : user.Status)),
                new Sql.Parameter("@Picture", DbType.Binary, (user == null || user.Picture == null ? (object)DBNull.Value : user.Picture)),
                new Sql.Parameter("@CreatedAt", DbType.DateTime, (user == null || user.CreatedAt == null ? (object)DBNull.Value : user.CreatedAt))
            };
        }
    }
}
