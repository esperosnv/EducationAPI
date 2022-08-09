using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.Material
{
    public class PutMaterialsDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
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
