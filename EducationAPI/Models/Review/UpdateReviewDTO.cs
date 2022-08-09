using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Models.Review
{
    public class UpdateReviewDTO
    {
        public string? Text { get; set; }
        public int? MaterialID { get; set; }
        [Range(0, 10)]
        public int? Rating { get; set; }
    }
}
