using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.Author
{
    public class CreateAuthorDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
