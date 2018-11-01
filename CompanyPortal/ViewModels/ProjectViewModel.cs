using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyPortal.ViewModels
{
    public class ProjectViewModel
    {
        public int? PId{ get; set; }
        
        public string Project_Name { get; set; }
        
        public string Mgr_Id { get; set; }
        
        public string Status{ get; set; }
        
        public string Description{ get; set; }
        public string UpdatedBy { get; set; }
        public List<AddProjectTechStackViewModel> ProjectTechStackList { get; set; }

    }
}