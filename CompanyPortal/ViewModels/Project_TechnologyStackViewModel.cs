using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyPortal.ViewModels
{
    public class Project_TechnologyStackViewModel
    {
        [Required]
        public string Technology { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int projectId { get; set; }
    }
}