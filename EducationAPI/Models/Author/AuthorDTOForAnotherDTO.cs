using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.Author
{
    public class AuthorDTOForAnotherDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<string> Materials { get; set; }
        [Required]
        public uint MaterialsCount { get; set; }
    }
}
