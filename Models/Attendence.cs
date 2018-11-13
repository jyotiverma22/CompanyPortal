using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //attendence model 
   public class Attendence
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string LogInTime{ get; set; }
        public string LogOutTime { get; set; }
        public string TotalTime { get; set; }
        public string AttendenceStatus{ get; set; }
        [Required]
        public string Emp_Id { get; set; }
        
    }
}
