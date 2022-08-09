using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.User
{
    public class RegisterUserDTO
    {
        // public string Email { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        // public int RoleId { get; set; } = 1;
    }
}
