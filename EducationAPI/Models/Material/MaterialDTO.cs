using EducationAPI.Models.Author;
using EducationAPI.Models.Review;
using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.Material
{
    public class MaterialDTO
    {
        [Required]
        public int MaterialID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string MaterialType { get; set; }
        [Required]
        public IEnumerable<ReviewDTO> Reviews { get; set; }
        [Required]
        public DateTime PublishingDate { get; set; }
        public double AverageRating { get; set; }
    }
}
