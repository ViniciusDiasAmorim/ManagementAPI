using Gerenciador.Context;
using Gerenciador.Models;
using Gerenciador.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.Results;

namespace Gerenciador.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ManagementContext _context;
        public ProductRepository(ManagementContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> ProductsGetAll()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }
        public async Task<Product> GetProductById(int id)
        {
            var productById = await _context.Products.Where(prod => prod.Id == id).FirstOrDefaultAsync();

            return productById;
        }
        public async Task<bool> Post(Product product)
        {

            bool isValid = Validation(product);

            if(!isValid)
            {
                return false;
            }

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Put(Product product, int id)
        {
            var productAfterChange = _context.Products.Where(p => p.Id == id).FirstOrDefault();

            if (product == null)
            {
                return false;
            }

            productAfterChange.Name = product.Name;
            productAfterChange.Description = product.Description;
            productAfterChange.Price = product.Price;
            productAfterChange.Stock = product.Stock;

            bool isValid = Validation(productAfterChange);

            if (!isValid)
            {
                return false;
            }
            
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Product> Delete(int id)
        {
            var produto = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (produto != null)
            {
                _context.Remove(produto);

                await _context.SaveChangesAsync();

                return produto;
            }
            return null;
        }

        public bool Validation(Product product)
        {

            var validationResults = new List<ValidationResult>();

            var validationContext = new ValidationContext(product);

            if (!Validator.TryValidateObject(product, validationContext, validationResults))
            {
                foreach (var validationResult in validationResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }

                return false;
            }

            return true;
        }
    }
}
