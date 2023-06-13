using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciador.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name field needs to be filled in")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "The Name needs a minimum of 5 characters and a maximum of 40 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The description field needs to be filled in")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "The description needs a minimum of 5 characters and a maximum of 150 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The price field needs to be filled in.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
