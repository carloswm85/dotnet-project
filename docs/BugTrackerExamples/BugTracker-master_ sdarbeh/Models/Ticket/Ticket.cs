using System;
using System.Collections.Generic;

namespace BugTrackerAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public int Priority { get; set; }
        public int productionState { get; set; }
        public string Notes { get; set; }
        // public ICollection<Employee> ActiveEmployees { get; set; }
        // public int EmployeeId { get; set; }
        
    }
}