using Gerenciador.Context;
using Gerenciador.DTO;
using Gerenciador.Models;

namespace Gerenciador.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(User user, Dictionary<Product, int> products);

    }
}