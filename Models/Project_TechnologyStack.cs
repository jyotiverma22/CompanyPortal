using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Project_TechnologyStack
    {
        [Key]
        public int Id { get; set; }
        public string Technology { get; set; }
        public string  UserId { get; set; }
        public int projectId { get; set; }
        public Project project { get; set; }

    }
}
