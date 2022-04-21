using System.ComponentModel.DataAnnotations;

namespace MedicationsAPI.Models
{
    public class Medication
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The quantity should be greater than 0")]
        public int Quantity { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public Medication(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
