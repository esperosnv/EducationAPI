using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Data.Entities
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}
