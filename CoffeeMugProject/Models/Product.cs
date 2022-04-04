using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeMugProject.Models
{
    public class Product
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public int Number { get; set; }

        public int Quantity { get; set; }

        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required, Range(0.01, double.PositiveInfinity)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
