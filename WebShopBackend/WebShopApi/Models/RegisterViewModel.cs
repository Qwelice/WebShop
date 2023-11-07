using System.ComponentModel.DataAnnotations;

namespace WebShopApi.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
