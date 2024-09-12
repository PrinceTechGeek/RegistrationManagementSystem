using EventRegistrationSystem.Application.Interfaces;
using EventRegistrationSystem.Domain.DTOs;
using EventRegistrationSystem.Domain.Entities;
using EventRegistrationSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventRegistrationSystem.Application.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationDbContext _context;

        public RegistrationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegistrationDto>> GetAllRegistrationsAsync()
        {
            return await _context.Registrations
                .Select(r => new RegistrationDto
                {
                    RegistrationId = r.RegistrationId,
                    EventName = r.EventName,
                    ParticipantName = r.ParticipantName,
                    EmailAddress = r.EmailAddress,
                    NumberOfTickets = r.NumberOfTickets,
                    EventType = r.EventType
                })
                .ToListAsync();
        }

        public async Task AddRegistrationAsync(RegistrationDto registration)
        {
            var entity = new Registration
            {
                RegistrationId = registration.RegistrationId ?? Guid.NewGuid(),
                EventName = registration.EventName,
                ParticipantName = registration.ParticipantName,
                EmailAddress = registration.EmailAddress,
                NumberOfTickets = registration.NumberOfTickets,
                EventType = registration.EventType
            };
            _context.Registrations.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
