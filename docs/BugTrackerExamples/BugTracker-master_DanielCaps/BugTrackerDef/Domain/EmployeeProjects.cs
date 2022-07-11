using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerDef.Domain
{
    public class EmployeeProjects
    {
        public int ProjectId { get; set; }
        public virtual Project Project{ get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
