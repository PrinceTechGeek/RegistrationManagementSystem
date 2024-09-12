using EventRegistrationSystem.Domain.Entities;
using EventRegistrationSystem.Domain.Interfaces;
using EventRegistrationSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventRegistrationSystem.Infrastructure.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDbContext _context;

        public RegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddRegistrationAsync(Registration registration)
        {
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();
            return registration.RegistrationId;
        }

        public async Task<Registration> GetRegistrationByIdAsync(Guid registrationId)
        {
            return await _context.Registrations.FindAsync(registrationId);
        }

        public async Task<IEnumerable<Registration>> GetAllRegistrationsAsync()
        {
            return await _context.Registrations.ToListAsync();
        }
    }
}
