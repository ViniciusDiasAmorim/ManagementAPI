using Gerenciador.Models;

namespace Gerenciador.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> ProductsGetAll();
        Task<Product> GetProductById(int id);
        Task<bool> Post(Product product);
        Task <bool> Put(Product product, int id);
        Task<Product> Delete(int id);
    }
}
