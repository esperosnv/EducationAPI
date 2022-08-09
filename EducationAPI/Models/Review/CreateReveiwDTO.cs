using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.Review
{
    public class CreateReveiwDTO
    {
        [Required]
        [MaxLength(1000, ErrorMessage = "The name cannot exceed 1000 characters")]
        public string Text { get; set; }
        [Required]
        public int MaterialID { get; set; }
        [Required]
        [Range(0, 10)]
        public int Rating { get; set; }
    }
}
