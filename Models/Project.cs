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
        [Required]
        public string ProjectName{ get; set; }
        [Required]
        public string Mgr_Id{ get; set; }
        [Required]
        public string Status { get; set; } //status shows project is completed or in working status
        [Required]
        public string Description { get; set; }
       
        public string CreatedBy{ get; set; }
        
        public DateTime CreatedOn { get; set; }
        [Required]
        public string UpdatedBy{ get; set; }
        [Required]
        public DateTime UpdatedOn{ get; set; }
        public bool IsActive{ get; set; }
        public List<Project_TechnologyStack> project_TechnologyStacks{ get; set; }
    }
}
