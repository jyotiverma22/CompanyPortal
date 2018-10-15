﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public  class Logs
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date{ get; set; }
        public string Thread{ get; set; }
        public string Level{ get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }

    }
}
