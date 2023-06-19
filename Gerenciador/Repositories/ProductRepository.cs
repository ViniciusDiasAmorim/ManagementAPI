using Gerenciador.Context;
using Gerenciador.Models;
using Gerenciador.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
            var productById = await _context.Products.FirstOrDefaultAsync(prod => prod.Id == id);

            return productById;
        }
        public async Task<Product> Post(Product product)
        {
            bool isValid = Validation(product);

            if (!isValid)
            {
                return null;
            }

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Put(Product product, int id)
        {
            var productChange = _context.Products.Where(p => p.Id == id).FirstOrDefault();

            if (productChange == null)
            {
                return null;
            }

            productChange.Name = product.Name;
            productChange.Description = product.Description;
            productChange.Price = product.Price;
            productChange.Stock = product.Stock;

            bool isValid = Validation(productChange);

            if (!isValid)
            {
                return null;
            }

            await _context.SaveChangesAsync();

            return productChange;
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
