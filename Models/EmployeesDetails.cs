using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //custom model for getting the employee details
  public  class EmployeesDetails
    {
        [Key]
        public string userId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Bloodgroup { get; set; }
        [Required]
        public string DOB { get; set; }
        
        public string Department_name { get; set; }
        [Required]
        public string Role_name { get; set; }

        public string Rep_Manager { get; set; }



    }
}
