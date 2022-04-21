using MedicationsAPI.Data;
using MedicationsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicationsAPI.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly MedicationsContext _context;

        public MedicationService(MedicationsContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Medication medication)
        {
            _context.Medications.Add(medication);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var medication = _context.Medications.FirstOrDefault(m => m.Id == id);
            if (medication == null)
            {
                return false;
            }
            _context.Medications.Remove(medication);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Medication>> GetAllAsync()
        {
            var medications = await _context.Medications.ToListAsync();
            return medications;
        }

        public async Task<Medication> GetMedicationAsync(Guid id)
        {
            var medication = await _context.Medications.FirstOrDefaultAsync(m => m.Id == id);
            return medication;
        }
    }
}
