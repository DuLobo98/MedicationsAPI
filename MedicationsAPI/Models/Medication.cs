using System.ComponentModel.DataAnnotations;

namespace MedicationsAPI.Models
{
    public class Medication
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,double.MaxValue)]
        public int Quantity { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public Medication(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
