using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.Material
{
    public class CreateMaterialDTO
    {
        [Required]
        [MaxLength(200, ErrorMessage = "The name cannot exceed 200 characters")]
        public string Title { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "The name cannot exceed 500 characters")]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int AuthorID { get; set; }
        [Required]
        public int MaterialTypeID { get; set; }
        [Required]
        public DateTime PublishingDate { get; set; }
    }
}
