using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using apifreader.DbLayer;
using apifreader.Models;

namespace apifreader.DataAccessLayer
{
    public partial class Repository : IRepository
    {
        private readonly gothamEntities1 _gothamEntities1;
        public Repository(gothamEntities1 gothamEntities1)
        {
            _gothamEntities1 = gothamEntities1;
        }

        public void AddUser(User user)
        {
            var username = new SqlParameter("@username", user.username);
            var password = new SqlParameter("@password", user.password);
            _gothamEntities1.Database.ExecuteSqlCommand("Exec adduserinfo @username,@password",username,password);
        }

        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> users = _gothamEntities1.Database.SqlQuery<User>("Select * from config.users").ToList<User>() ;
            return users;
        }

        public User GetUser(String username)
        {
            User user = _gothamEntities1.Database.SqlQuery<User>("Select * from config.users where username= '"+username+"'").FirstOrDefault<User>();
            return user;
        }

        public void DeleteUser(User user)
        {
            var username = new SqlParameter("@username", user.username);
            var password = new SqlParameter("@password", user.password);
            _gothamEntities1.Database.ExecuteSqlCommand("Exec deleteuserinfo @username,@password", username, password);
        }

        public void ChangePassword(User user)
        {
            var username = new SqlParameter("@username", user.username);
            var password = new SqlParameter("@password", user.password);
            var newpassword = new SqlParameter("@newpassword", user.newPassword);
            _gothamEntities1.Database.ExecuteSqlCommand("Exec changePassword @username,@password,@newpassword", username, password,newpassword);
        }

        public IEnumerable<Movie> getAllMovies()
        {
            IEnumerable<Movie> movies = _gothamEntities1.Database.SqlQuery<Movie>("Select * from config.movies").ToList<Movie>();
            return movies;
        
        }

        public String Login(User user)
        {
            var username = new SqlParameter("@username", user.username);
            var password = new SqlParameter("@password", user.password);
            String key=_gothamEntities1.Database.SqlQuery<String>("Exec login @username,@password", username, password).FirstOrDefault<String>();
            return key;
        }
    }
}