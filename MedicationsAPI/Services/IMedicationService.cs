using MedicationsAPI.Models;

namespace MedicationsAPI.Services
{
    public interface IMedicationService
    {
        Task<List<Medication>> GetAllAsync();

        Task<Medication> GetMedicationAsync(Guid id);
        Task CreateAsync(Medication medication);
        Task<bool> DeleteAsync(Guid id);

    }
}
