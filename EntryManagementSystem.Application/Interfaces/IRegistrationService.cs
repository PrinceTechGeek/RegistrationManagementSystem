using EventRegistrationSystem.Domain.DTOs;

namespace EventRegistrationSystem.Application.Interfaces
{
    public interface IRegistrationService
    {
        Task<IEnumerable<RegistrationDto>> GetAllRegistrationsAsync();
        Task AddRegistrationAsync(RegistrationDto registration);
    }
}
