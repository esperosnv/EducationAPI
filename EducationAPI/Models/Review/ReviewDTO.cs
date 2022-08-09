using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.Review
{
    public class ReviewDTO
    {
        [Required]
        public int ReviewID { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
