using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Attendence
    {
        [Key]
        public int Id { get; set; }
        public string Date { get; set; }
        public string LogInTime{ get; set; }
        public string LogOutTime { get; set; }
        public string TotalTime { get; set; }
        public string Status{ get; set; }
        public string Emp_Id { get; set; }
        
    }
}
