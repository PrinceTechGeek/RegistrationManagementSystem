using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.MVC.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Event Name is required")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Participant Name is required")]
        public string ParticipantName { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Number of Tickets is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of Tickets must be greater than 0")]
        public int NumberOfTickets { get; set; }

        [Required(ErrorMessage = "Event Type is required")]
        public string EventType { get; set; }
    }
}
