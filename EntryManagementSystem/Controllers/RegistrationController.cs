using EventRegistrationSystem.Application.Interfaces;
using EventRegistrationSystem.Domain.DTOs;
using EventRegistrationSystem.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventRegistrationSystem.MVC.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public async Task<IActionResult> Index()
        {
            var registrationDtos = await _registrationService.GetAllRegistrationsAsync();

            var registrationViewModels = registrationDtos.Select(dto => new RegistrationViewModel
            {
                EventName = dto.EventName,
                ParticipantName = dto.ParticipantName,
                EmailAddress = dto.EmailAddress,
                NumberOfTickets = dto.NumberOfTickets,
                EventType = dto.EventType
            }).ToList();

            return View(registrationViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new RegistrationViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var registrationDto = new RegistrationDto
                {
                    EventName = model.EventName,
                    ParticipantName = model.ParticipantName,
                    EmailAddress = model.EmailAddress,
                    NumberOfTickets = model.NumberOfTickets,
                    EventType = model.EventType
                };

                await _registrationService.AddRegistrationAsync(registrationDto);
                return RedirectToAction("Success");
            }
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
