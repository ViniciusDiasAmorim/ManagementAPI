using System.ComponentModel.DataAnnotations;

namespace Gerenciador.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name field needs to be filled in")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "The Name needs a minimum of 5 characters and a maximum of 40 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Document field needs to be filled in")]
        [StringLength(9, ErrorMessage = "The document is not valid, it needs to have 9 digits.")]
        public string Document { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
