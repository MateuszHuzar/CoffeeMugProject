using CoffeeMugProject.Dto;
using CoffeeMugProject.Interfaces;
using CoffeeMugProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMugProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            return Ok((await _service.GetAllProducts()).Select(p => ProductToDto(p)));
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(Guid id)
        {
            var product = await _service.GetProductById(id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(ProductToDto(product));
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult> Post(ProductPostDto product)
        {
            var newproductId = await _service.AddProduct(product);

            return CreatedAtAction(nameof(Get), new { id = newproductId });

        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Put(Guid id, ProductEditDto product)
        {
            var productToChange = await _service.GetProductById(id);
            if(productToChange == null)
            {
                return NotFound();
            }

            return Ok(ProductToDto(await _service.UpdateProduct(id, product)));
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var productForDelete = await _service.GetProductById(id);
            if (productForDelete == null)
            {
                return NotFound();
            }
            await _service.DeleteProduct(id);

            return NoContent();
        }

        private static ProductDto ProductToDto(Product product)
        {
            return new ProductDto()
            {
                ID = product.ID,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Number = product.Number,
                Quantity = product.Quantity
            };
        }
    }
}
