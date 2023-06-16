using System.Text.Json.Serialization;

namespace Gerenciador.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
