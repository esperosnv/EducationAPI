using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.User
{
    public class LoginDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
