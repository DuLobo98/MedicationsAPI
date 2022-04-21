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
        public async Task<ActionResult<List<Medication>>> GetAllMedications()
        {
            var medications = await _medicationService.GetAllAsync();
            return Ok(medications);
        }

        [HttpPost()]
        public async Task<ActionResult<Medication>> CreateMedication(Medication medication)
        {
            await _medicationService.CreateAsync(medication);

            var locationToReturn = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}/api/Medications/{medication.Id}";

            var medicationToReturn = await _medicationService.GetMedicationAsync(medication.Id);

            return Created(locationToReturn, medicationToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMedication(Guid id)
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
