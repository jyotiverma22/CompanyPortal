using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class JQGridParameter
    {
        public string SortBy{ get; set; }
        public string OrderBy{ get; set; }
        public int Page{ get; set; }
        public int Rows{ get; set; }
        public bool _search { get; set; }
        public string SearchField { get; set; }
        public string SearchString { get; set; }
        public string filters { get; set; }
    }
}
