using Gerenciador.Context;
using Gerenciador.DTO;
using Gerenciador.Models;
using Gerenciador.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ManagementContext _context;
        public OrderRepository(ManagementContext context)
        {
            _context = context;
        }
        public async Task<Order> CreateOrder(User user, Dictionary<Product, int> products)
        {
            Order order = new Order();

            order.User = user;

            foreach (var item in products)
            {
                var itemProduct = new OrderItems()
                {
                    OrderId = order.Id,
                    ProductId = item.Key.Id,
                    Amount = item.Value
                };

                order.OrderItems.Add(itemProduct);

                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.Key.Id);
                product.Stock -= item.Value;
            }

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return order;
        }
    }
}