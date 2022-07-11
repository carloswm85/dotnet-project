using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerDef.Models.ViewModels
{
    public class UserViewModel
    {
        public int EmployeeId { get; set; }
        
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [Phone]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
    }
}
