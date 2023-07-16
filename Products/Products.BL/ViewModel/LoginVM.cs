using System.ComponentModel.DataAnnotations;

namespace Products.BL.ViewModel
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public bool IsPresistent { get; set; }


    }
}
