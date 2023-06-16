using Gerenciador.Models.Enums;

namespace Gerenciador.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public List<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    }
}
