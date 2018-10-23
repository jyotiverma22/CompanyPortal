using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// model for storing the details into the database
    /// </summary>
  public  class Registration
    {
        [Key]
        public int Sno{ get; set; }
        public string UserId { get; set; }
        public string Username{ get; set; }
        public string Email { get; set; }
        public string Phone{ get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender{ get; set; }
        public string DOB{ get; set; }
        public int BId { get; set; }
        public BloodGroup bloodGroup{ get; set; }
        public int DId { get; set; }
        public Department department { get; set; }
        public int RId { get; set; }
        public Role role { get; set; }
        public string R_M_Id { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
