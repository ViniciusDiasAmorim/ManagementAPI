namespace Gerenciador.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        List<OrderItems> OrderItems { get; set; }
    }
}
