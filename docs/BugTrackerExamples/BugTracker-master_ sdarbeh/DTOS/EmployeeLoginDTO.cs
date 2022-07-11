using System.ComponentModel.DataAnnotations;

namespace BugTrackerAPI.DTOS.employee
{
    // object class for logins
    public class EmployeeLoginDTO
    {
        // email
        [Required(ErrorMessage = "Please enter an email")]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        // password
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
    }
}