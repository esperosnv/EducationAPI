using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.Review
{
    public class PutReviewDTO
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public int MaterialID { get; set; }
        [Required]
        [Range(0, 10)]
        public uint Rating { get; set; }
    }
}
