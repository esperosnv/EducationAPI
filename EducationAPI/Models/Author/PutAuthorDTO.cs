using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.Author
{
    public class PutAuthorDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
