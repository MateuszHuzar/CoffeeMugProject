using CoffeeMugProject.Data;
using CoffeeMugProject.Dto;
using CoffeeMugProject.Interfaces;
using CoffeeMugProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMugProject.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;

        public ProductService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddProduct(ProductPostDto product)
        {
            var productForAdd = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Quantity = product.Quantity,
                Number = product.Number,
                Price = product.Price
            };
            await _context.Products.AddAsync(productForAdd);
            await _context.SaveChangesAsync();
            return productForAdd.ID;
        }

        public async Task DeleteProduct(Guid id)
        {
            var productForDelete = await _context.Products.FirstAsync(p => p.ID == id);
            _context.Products.Remove(productForDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> UpdateProduct(Guid id, ProductEditDto product)
        {
            var productForUpdate = await _context.Products.FirstAsync(p => p.ID == id);
            productForUpdate.Quantity = product.Quantity;
            productForUpdate.Description = product.Description;
            await _context.SaveChangesAsync();
            return productForUpdate;
        }
    }
}
