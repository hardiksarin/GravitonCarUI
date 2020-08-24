using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitonCarLibrary.Models
{
    public class UserModel
    {
        public int user_id { get; set; }
        public string full_name { get; set; }
        public string username { get; set; }
        public string designation { get; set; }
        public string user_dob { get; set; }
        public string password { get; set; }
        public string permissions { get; set; }
    }
}
