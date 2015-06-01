using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHome.Models
{
    public class CurrentUser
    {
        public string Login { get; set; }
        string Password { get; set; }
        string Email { get; set; }
        int Rooms { get; set; }
        public CurrentUser()
        {
            Login = "Owner1";
        }
    }
}