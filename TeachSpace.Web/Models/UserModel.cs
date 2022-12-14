using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeachSpace.Web.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public bool IsAdmin { get; set; }
    }
}