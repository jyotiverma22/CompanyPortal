using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// model for project entity into the database
    /// </summary>
  public  class ProjectModel
    {
        public int PId { get; set; }

        public string Project_Name { get; set; }

        public string Manager_Name { get; set; }

        public string Status { get; set; }
    }
}
