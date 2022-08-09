using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.User
{
    public class RegisterUserDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
