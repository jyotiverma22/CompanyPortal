using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class BloodGroup
    {
        [Key]
        public int Id{ get; set; }
        public string BloodGroupName{ get; set; }
        public string Active{ get; set; }
        public List<Registration> Users{ get; set; }
    }
}
