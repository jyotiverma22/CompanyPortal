using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Role
    {
        public int RID { get; set; }
        public string RoleName{ get; set; }
        public string Active { get; set; }
        public List<Registration> Users { get; set; }
    }
}
