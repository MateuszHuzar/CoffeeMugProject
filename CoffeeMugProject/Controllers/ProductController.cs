using CoffeeMugProject.Data;
using CoffeeMugProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMugProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(Guid id)
        {
            var product = await _context.Products.FindAsync(id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            var addedProduct = _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = product.ID }, product);
        }
        
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Put(Product product)
        {
            var productToChange = await _context.Products.FindAsync(product.ID);
            if(productToChange == null)
            {
                return NotFound();
            }

            productToChange.Description = product.Description;
            productToChange.Quantity = product.Quantity;

            await _context.SaveChangesAsync();
            return Ok(product.ID);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var productForDelete = await _context.Products.FindAsync(id);
            if(productForDelete == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productForDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
