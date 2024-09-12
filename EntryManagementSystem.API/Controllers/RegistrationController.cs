using EventRegistrationSystem.Application.Interfaces;
using EventRegistrationSystem.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventRegistrationSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistrations()
        {
            var registrations = _registrationService.GetAllRegistrationsAsync();
            return Ok(registrations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistration([FromBody] RegistrationDto registration)
        {
            if (ModelState.IsValid)
            {
                 _registrationService.AddRegistrationAsync(registration);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
