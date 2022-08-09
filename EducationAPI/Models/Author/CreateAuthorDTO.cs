using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.Author
{
    public class CreateAuthorDTO
    {
        [Required]
        [MaxLength(200, ErrorMessage = "The name cannot exceed 200 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "The name cannot exceed 500 characters")]
        public string Description { get; set; }
    }
}
