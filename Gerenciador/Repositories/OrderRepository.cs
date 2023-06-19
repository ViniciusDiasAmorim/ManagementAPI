using Gerenciador.Context;
using Gerenciador.Models;
using Gerenciador.Models.Enums;
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

        public async Task<IEnumerable<Order>> GetOrdersByUserID(int id)
        {
            return await _context.Orders.Where(u => u.User.Id == id).Include(i => i.OrderItems).ToListAsync();
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

        public async Task<bool> DeliveryOrder(Guid orderID)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id  == orderID);
            if(order == null)
            {
                return false;
            }

            order.Status = OrderStatus.Delivered;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}