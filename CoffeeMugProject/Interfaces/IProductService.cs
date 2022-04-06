using CoffeeMugProject.Dto;
using CoffeeMugProject.Models;

namespace CoffeeMugProject.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product?> GetProductById(Guid id);

        Task<Guid> AddProduct(ProductPostDto product);

        Task<Product> UpdateProduct(Guid id, ProductEditDto product);

        Task DeleteProduct(Guid id);
    }
}
