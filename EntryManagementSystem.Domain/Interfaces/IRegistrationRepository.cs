using System;
using System.Collections.Generic;
using EventRegistrationSystem.Domain.Entities;

namespace EventRegistrationSystem.Domain.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<Guid> AddRegistrationAsync(Registration registration);
        Task<Registration> GetRegistrationByIdAsync(Guid registrationId);
        Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
    }
}
