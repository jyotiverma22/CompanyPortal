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
        public string Mgr_Id{ get; set; }
        public string Status { get; set; } //status shows project is completed or in working status
        public string Description { get; set; }
        public string CreatedBy{ get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy{ get; set; }
        public DateTime UpdatedOn{ get; set; }
        public string Active{ get; set; }
        public List<Project_TechnologyStack> project_TechnologyStacks{ get; set; }
    }
}
