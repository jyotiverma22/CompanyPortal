using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class JQGridParameter
    {
        public string sortname{ get; set; }
        public string sord{ get; set; }
        public int page{ get; set; }
        public int rows{ get; set; }
        public bool _search { get; set; }
    }
}
