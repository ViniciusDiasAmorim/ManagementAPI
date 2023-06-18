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
        public async Task<Order> CreateOrder(CreateOrderDTO createOrderDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == createOrderDTO.UserId);

            if (user == null)
            {
                return null;
            }

            Order order = new Order();

            order.User = user;


            foreach (var item in createOrderDTO.orderItemDTOs)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.ProductId);

                if (product == null)
                {
                    return null;
                }

                var itemProduct = new OrderItems()
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Amount = item.Amount
                };

                order.OrderItems.Add(itemProduct);
            }

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return order;
        }
    }
}