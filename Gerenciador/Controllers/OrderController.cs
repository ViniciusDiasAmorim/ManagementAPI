using Gerenciador.DTO;
using Gerenciador.Models;
using Gerenciador.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderByUserId(int id)
        {
            var user = await _userRepository.GetById(id);
            
            if (user == null)
            {
                return BadRequest();
            }

            IEnumerable<Order> userOrders = await _orderRepository.GetOrdersByUserID(id);

            return Ok(userOrders);
        }
        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderDTO createOrderDTO)
        {
            var user = await _userRepository.GetById(createOrderDTO.UserId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            Dictionary<Product, int> products = new Dictionary<Product, int>();

            foreach (var item in createOrderDTO.orderItemDTOs)
            {
                var product = await _productRepository.GetProductById(item.ProductId);
                if (product == null)
                {
                    return NotFound($"Product not found");
                }
                if (product.Stock - item.Amount < 0)
                {
                    return BadRequest($"Not have this amount {product.Name} in stock");
                }
                products.Add(product, item.Amount);
            }

            var order = await _orderRepository.CreateOrder(user, products);

            if (order == null)
            {
                return BadRequest("Something is wrong");
            }

            return Ok(order);
        }
        [HttpPut]
        public async Task<ActionResult> DeliveryOrder(Guid id)
        {
            bool changeIsSucess = await _orderRepository.DeliveryOrder(id);

            if(!changeIsSucess)
            {
                return NotFound();
            }

            return Ok("Delivery is successuful");
        }
    }
}
