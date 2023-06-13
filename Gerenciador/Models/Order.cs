namespace Gerenciador.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        List<Product> Products { get; set; }
    }
}
