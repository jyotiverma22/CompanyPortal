using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //custom object for storing jqgrid parameters
   public class JQGridParameter
    {
        public string SortBy{ get; set; }
        public string OrderBy{ get; set; }
        public int Page{ get; set; }
        public int Rows{ get; set; }
        public bool _search { get; set; }
        public Filter filters { get; set; }
    }


    public class Filter
    {
        public string groupOp { get; set; }
        public List<Rule> rules { get; set; }
    }


    public class Rule
    {
        public string field { get; set; }
        public string op { get; set; }
        public string data { get; set; }
    }
}
