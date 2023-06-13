using Gerenciador.Context;
using Gerenciador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ManagementContext _managementContext;
        
        public ProductController(ManagementContext managementContext)
        {
            _managementContext = managementContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var products = await _managementContext.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
           var productById = _managementContext.Products.Where(prod => prod.Id == id).FirstOrDefault();
            if(productById == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(productById);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            if(product == null)
            {
                return BadRequest("The product is null");
            }

            _managementContext.Products.Add(product);

            await _managementContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Product prod)
        {
            var product = _managementContext.Products.FirstOrDefault(p => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            product.Name = prod.Name;
            product.Description = prod.Description;
            product.Price = prod.Price;
            product.Stock = prod.Stock;

            await _managementContext.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var prod = _managementContext.Products.FirstOrDefault(x => x.Id == id);

            if(prod == null)
            {
                return NotFound("Product not found");
            }
            _managementContext.Products.Remove(prod);

            await _managementContext.SaveChangesAsync();

            return Ok(prod);
        }
    }
}
