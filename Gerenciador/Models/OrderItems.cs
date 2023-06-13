namespace Gerenciador.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
