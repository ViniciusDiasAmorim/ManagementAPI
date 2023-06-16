using Gerenciador.Context;
using Gerenciador.DTO;
using Gerenciador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ManagementContext _managementContext;
        public OrderController(ManagementContext managementContext)
        {
            _managementContext = managementContext;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderDTO createOrderDTO)
        {
            var user = await _managementContext.Users.FirstOrDefaultAsync(u => u.Id == createOrderDTO.UserId);
            
            if (user == null)
            {
                return BadRequest("User not found");
            }

            Order order = new Order();
            
     
            foreach (var item in createOrderDTO.orderItemDTOs)
            {
                var product = await _managementContext.Products.FirstOrDefaultAsync(p => p.Id == item.ProductId);

                if (product == null)
                {
                    return BadRequest("User not found");
                }

                var itemProduct = new OrderItems()
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Amount = item.Amount
                };

                order.OrderItems.Add(itemProduct);
            }

            order.User = user;

            return Ok(order);
        }
    }
}
