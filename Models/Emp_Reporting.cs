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
        public int Id { get; set; }
        public int Emp_ID { get; set; }
        public int Rep_Mgr { get; set; }
    }
}
