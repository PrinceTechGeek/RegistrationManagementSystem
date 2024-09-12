using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.Domain.DTOs
{
    public class RegistrationDto
    {
        public Guid? RegistrationId { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public string ParticipantName { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int NumberOfTickets { get; set; }

        [Required]
        public string EventType { get; set; }
    }
}
