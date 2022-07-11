using System.ComponentModel.DataAnnotations;

namespace BugTrackerAPI.DTOS.ticket
{
    public class TicketCreateDTO
    {

        // title
        [Required(ErrorMessage = "Please enter a title")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Title must be between 3 to 255 characters")]
        public string Title { get; set; }

        // description
        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Description must be between 3 to 255 characters")]
        public string Description { get; set; }

        // website url
        [Required(ErrorMessage = "Please enter a website")]
        public string WebsiteUrl { get; set; }

        // priority
        [Required(ErrorMessage = "Please enter a priority level")]
        [Range(1, 3)]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number")]
        public int Priority { get; set; }
    }
}