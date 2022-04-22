using MedicationsAPI.Models;
using MedicationsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicationsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationsController : Controller
    {
        private readonly IMedicationService _medicationService;

        public MedicationsController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllMedicationsAsync()
        {
            var medications = await _medicationService.GetAllAsync();
            return Ok(medications);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateMedicationAsync(Medication medication)
        {
            await _medicationService.CreateAsync(medication);

            var locationToReturn = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}/api/Medications/{medication.Id}";

            var medicationToReturn = await _medicationService.GetMedicationAsync(medication.Id);

            return Created(locationToReturn, medicationToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicationAsync(Guid id)
        {
            var deleted = await _medicationService.DeleteAsync(id);
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
