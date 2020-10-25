using apifreader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apifreader.DataAccessLayer
{
    public interface IRepository
    {
        User GetUser(String username);

        IEnumerable<User> GetAllUsers();

        void AddUser(User user);

        void DeleteUser(User user);

        void ChangePassword(User user);

    }
}