using System;

namespace EventRegistrationSystem.Domain.Entities
{
    public class Registration
    {
        public Guid RegistrationId { get; set; }
        public string EventName { get; set; }
        public string ParticipantName { get; set; }
        public string EmailAddress { get; set; }
        public int NumberOfTickets { get; set; }
        public string EventType { get; set; }
    }
}
