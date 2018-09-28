using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class DbLogging
    {
        [Key]
        public int LoginId { get; set; }
        public string ExceptionType { get; set; }
        public string  ExceptionMessage{ get; set; }
        public string  ExceptionSource{ get; set; }
        public string  ExceptionUrl{ get; set; }
        public DateTime LogDate{ get; set; }
    }
}
