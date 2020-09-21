using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonCar.Models
{
    public class LoginCredentials
    {
        public string username { get; set; }
        public string password { get; set; }

        public LoginCredentials(string u, string p)
        {
            username = u;
            password = p;
        }
    }
}
