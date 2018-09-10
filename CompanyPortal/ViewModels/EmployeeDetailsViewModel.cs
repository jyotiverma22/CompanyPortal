using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyPortal.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public string userId { get; set; }

        //not editable
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 20 characters")]
        public string Username { get; set; }

        //not editable
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //editable
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; }

     

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Gender { get; set; }


        [Required]
        public string Bloodgroup { get; set; }

        public string DOB { get; set; }

        public string Department_name { get; set; }

        public string Role_name { get; set; }

        public string Rep_Manager { get; set; }
    }
}