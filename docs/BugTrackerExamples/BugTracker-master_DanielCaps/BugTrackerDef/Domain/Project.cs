using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerDef.Domain
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatorName { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<EmployeeProjects> EmployeeProjects { get; set; }

    }
}
