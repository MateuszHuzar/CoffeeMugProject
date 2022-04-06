using System.ComponentModel.DataAnnotations;

namespace CoffeeMugProject.Dto
{
    public class ProductEditDto
    {
        public int Quantity { get; set; }

        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
    }
}
