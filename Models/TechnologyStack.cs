using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TechnologyStack
    {
        [Key]
        public int Id{ get; set; }
        public string Technology { get; set; }
        public bool IsActive{ get; set; }
        public List<User_TechnologyStack> User_TechnologyStacks { get; set; }
        
    }
}
