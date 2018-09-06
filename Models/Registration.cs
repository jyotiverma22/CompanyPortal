using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
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
        public int Id { get; set; }
        public BloodGroup bloodGroup{ get; set; }

    }
}
