using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookself.Models
{
    public class User
    {
        public string Username { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Password { get; set; }
        public DateTime JoinDate { get; set; }
    }
}