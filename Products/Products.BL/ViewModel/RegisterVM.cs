using System.ComponentModel.DataAnnotations;

namespace Products.BL.ViewModel
{
    public class RegisterVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
