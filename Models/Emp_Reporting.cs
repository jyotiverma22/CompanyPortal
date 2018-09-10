using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
 public class Emp_Reporting
    {
        [Key]
        public int Emp_Rep_Id { get; set; }
        public string Emp_ID { get; set; }
        public string Rep_Mgr { get; set; }
    }
}
