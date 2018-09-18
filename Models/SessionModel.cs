using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    /// <summary>
    /// Model to get all the values from the database that we need to store in session 
    /// </summary>
  public  class SessionModel
    {
        public string userid { get; set; }
        public string rolename{ get; set; }
        public string firstname { get; set; }
        public string deptname{ get; set; }
    }
}
