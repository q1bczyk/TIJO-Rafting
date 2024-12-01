using System.ComponentModel.DataAnnotations;

namespace Project.Core.DTO.Auth
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}