using Gerenciador.Context;
using Gerenciador.DTO;
using Gerenciador.Models;
using Gerenciador.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderReposirory;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderReposirory = orderRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderDTO createOrderDTO)
        {
            var order = await _orderReposirory.CreateOrder(createOrderDTO);
            return Ok(order);
        }
    }
}
