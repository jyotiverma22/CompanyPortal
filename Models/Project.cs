using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public  class Project
    {
        [Key]
        public int PID{ get; set; }
        public string ProjectName{ get; set; }
        public int Mgr_Id{ get; set; }
        public string Status { get; set; }
    }
}
