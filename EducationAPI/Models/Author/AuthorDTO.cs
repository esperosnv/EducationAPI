using EducationAPI.Models.Material;
using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.Author
{
    public class AuthorDTO
    {
        [Required]
        public int AuthorID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<MaterialsDTOForAnotherDTO> Materials { get; set; }
        [Required]
        public uint MaterialsCount { get; set; }
    }
}
