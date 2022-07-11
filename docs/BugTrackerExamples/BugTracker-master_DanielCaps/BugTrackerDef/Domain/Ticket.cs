using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackerDef.Domain
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        public string Description { get; set; }
        [DisplayName("Assigned Dev")]
        public string AssignedDev { get; set; }
        public string Submitter { get; set; }
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        [DisplayName("Ticket Priority")]
        public string TicketPriority { get; set; }
        [DisplayName("Ticket Status")]
        public string TicketStatus { get; set; }
        [DisplayName("Ticket Type")]
        public string TicketType { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Updated Date")]
        public DateTime UpdatedDate { get; set; }
        public string Image { get; set; }
        public int EmployeeID { get; set; }

        [ForeignKey("Project")]
        public int Project_ID { get; set; }
        public virtual Project Project { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
