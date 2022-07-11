using BugTrackerDef.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTrackerDef.Models.ViewModels
{
    public class TicketViewModel
    {
        public int TicketID { get; set; }
        [Required]
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
        [Required]
        [DisplayName("Ticket Type")]
        public string TicketType { get; set; }
        public DateTime CreatedDate { get; set; }
        [DisplayName("Updated Date")]
        public DateTime UpdatedDate { get; set; }
        public IFormFile Image { get; set; }
        public string CurrentImage { get; set; }


        public int EmployeeID { get; set; }
        public int Project_ID { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
