using Bookself.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookself.DAL
{
    public interface IUserSource
    {
        List<User> GetUsers();
        User GetUser(int id);

    }
}