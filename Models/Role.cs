using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Model for the role entity
    /// </summary>
   public class Role
    {
        [Key]
        public int RID { get; set; }
        public string RoleName{ get; set; }
        public string Active { get; set; }
        public List<Registration> Users { get; set; }
    }
}
