using System.ComponentModel.DataAnnotations;

namespace BugTrackerAPI.DTOS.employee
{
    // object class for new employee registration
    public class EmployeeCreateDTO
    {
        // firstname
        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 to 50 characters")]
        public string FirstName { get; set; }

        // lastname
        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 to 50 characters")]
        public string LastName { get; set; }

        // email
        [Required(ErrorMessage = "Please enter an email")]
        [StringLength(255, MinimumLength = 3)]
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        // password
        [Required(ErrorMessage = "Please enter password")]
        [StringLength(13, MinimumLength = 8, ErrorMessage = "Password must be between 8 to 13 characters")]
        public string Password { get; set; }
    }
}