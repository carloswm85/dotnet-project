using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking.Models
{
    public class Bug
    {
        public int Id { get; set; }

        public string Title {get;set;}

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public Prioriry Priority { get; set; }
    }
}
