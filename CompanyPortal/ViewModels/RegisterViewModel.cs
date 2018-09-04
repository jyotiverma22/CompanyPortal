using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Models.BloodGroupList;

namespace CompanyPortal.ViewModels
{
    public class RegisterViewModel
    {
        public string userId{ get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 20 characters")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 20 characters")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password does not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Gender { get; set; }
        

        [Required]
        public string Bloodgroup { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DOB { get; set; }


    }
    public enum BloodGroup
    {
        [Display(Name = "O+")]
        OPositive,
        [Display(Name = "A+")]
        APositive,
        [Display(Name = "B+")]
        BPositive,
        [Display(Name = "AB+")]
        ABPositive,
        [Display(Name = "AB-")]
        ABNegative,
        [Display(Name = "A-")]
        ANegative,
        [Display(Name = "B-")]
        BNegative,
        [Display(Name = "O-")]
        ONegative
    }
}