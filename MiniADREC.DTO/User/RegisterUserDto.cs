using System.ComponentModel.DataAnnotations;

namespace MiniADREC.DTO.User
{
    public class RegisterUserDto
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }
    }
}
