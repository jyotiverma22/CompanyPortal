using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //model for sending only username and password to server
   public class Login
    {
        public string Username{ get; set; }
        public string Password{ get; set; }
    }
}
