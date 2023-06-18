using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gerenciador.DTO
{
    public class CreateOrderDTO
    {
        public int UserId { get; set; }
        [ValidateNever]
        public List<OrderItemDTO> orderItemDTOs { get; set; }
    }
}
