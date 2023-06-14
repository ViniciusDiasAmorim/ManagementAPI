using Gerenciador.Models;

namespace Gerenciador.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> ProductsGetAll();
        Task<Product> GetProductById(int id);
        Task<Product> Post(Product product);
        Task <Product> Put(Product product, int id);
        Task<Product> Delete(int id);
    }
}
