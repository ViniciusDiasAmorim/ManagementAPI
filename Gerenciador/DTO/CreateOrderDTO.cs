using Gerenciador.Models;
// Recebo 1 userId, crio uma order , populo a order com as order items.

namespace Gerenciador.DTO
{
    public class CreateOrderDTO
    {
        public int UserId { get; set; }
        public List<OrderItemDTO> orderItemDTOs { get; set; }
    }
}
