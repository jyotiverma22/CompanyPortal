using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Project_Team
    {
        [Key]
        public int Id { get; set; }
        public int PId { get; set; }
        public string Mgr_Id{ get; set; }
        public string Team_Id{ get; set; }
    }
}
