using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class User_TechnologyStack
    {
        [Key]
        public int Id{ get; set; }
        public string UserId{ get; set; }
        public int technologyStackId { get; set; }
        public TechnologyStack technologyStack{ get; set; }
        public bool IsActive { get; set; }

    }
}
