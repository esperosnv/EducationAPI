using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Data.Entities
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int MaterialID { get; set; }
        [Required]
        public Material Material { get; set; }
        [Range(0, 10)]
        public int Rating { get; set; }

    }
}
