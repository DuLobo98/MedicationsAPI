using MedicationsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicationsAPI.Data
{
    public class MedicationsContext : DbContext
    {
        public MedicationsContext(DbContextOptions<MedicationsContext> options) : base(options)
        {
        }

        public DbSet<Medication> Medications { get; set; }
    }
}
