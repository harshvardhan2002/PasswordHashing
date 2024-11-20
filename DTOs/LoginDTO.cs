using System.ComponentModel.DataAnnotations;

namespace PasswordHashing.DTOs
{
    public class LoginDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Username must be between 8 to 20 characters")]
        public string UserName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Password must be in between 8 to 15 characters")]
        public string Password { get; set; }
    }
}
