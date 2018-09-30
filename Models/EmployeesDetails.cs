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

        public string Username { get; set; }

         public string Email { get; set; }

         public string Phone { get; set; }

         public string FullName { get; set; }

          public string Gender { get; set; }


         public string Bloodgroup { get; set; }
         public string DOB { get; set; }

        public string Department_name { get; set; }

        public string Role_name { get; set; }

        public string Rep_Manager { get; set; }

    }
}
