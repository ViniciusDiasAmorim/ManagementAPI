using Gerenciador.Models;
using Gerenciador.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _produtoRepository;
        public ProductController(IProductRepository productRepository)
        {
            _produtoRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var products = await _produtoRepository.ProductsGetAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var productById = await _produtoRepository.GetProductById(id);

            if (productById == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(productById);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("The product is null");
            }

            var produtctChange = await _produtoRepository.Post(product);

            if (produtctChange == null)
            {
                return BadRequest("Past properties are invalid");
            }

            return Ok(produtctChange);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Product prod)
        {
            var product = await _produtoRepository.Put(prod, id);

            if (product == null)
            {
                return BadRequest("Past properties are invalid");
            }

            return Ok(prod);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           var produto = await _produtoRepository.Delete(id);

            if (produto == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(produto);
        }
    }
}
