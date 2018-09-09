using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Department
    {
        public int DId{ get; set; }

        public string Dname{ get; set; }

        public string Active{ get; set; }

        public List<Registration> Users { get; set; }
    }
}
