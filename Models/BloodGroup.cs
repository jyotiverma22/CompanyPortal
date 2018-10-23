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
        public int BId{ get; set; }
        public string BloodGroupName{ get; set; }
        public bool IsActive{ get; set; }
        public List<Registration> Users{ get; set; }
    }
}
