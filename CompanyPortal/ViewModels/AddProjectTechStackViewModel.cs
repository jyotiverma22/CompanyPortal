using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyPortal.ViewModels
{
    public class AddProjectTechStackViewModel
    {
        [Required]
        public string Technology { get; set; }
        [Required]
        public string UserId { get; set; }
    }

    public class ProjectTechnologyList {
        public List<AddProjectTechStackViewModel> ProjectTechStackList { get; set; }
    }
}