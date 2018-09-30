using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //model for department details
   public class Department
    {[Key]
        public int DId{ get; set; }

        public string Dname{ get; set; }

        public string Active{ get; set; }

        public List<Registration> Users { get; set; }
    }
}
