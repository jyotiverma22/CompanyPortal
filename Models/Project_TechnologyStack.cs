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
        [Required]
        public string Technology { get; set; }
        [Required]
        public string  UserId { get; set; }
        [Required]
        public int projectId { get; set; }
        public Project project { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}
