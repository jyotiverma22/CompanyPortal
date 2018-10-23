using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //model for storing the ids of members assigned to a perticular project

    public class Project_Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PId { get; set; } //Project id
        [Required]
        public string Mgr_Id{ get; set; }  //manager id
        [Required]
        public string Team_Id{ get; set; }  // team member id
    }
}
