using System.ComponentModel.DataAnnotations;


namespace EducationAPI.Data.Entities
{
    public class Material
    {
        [Key]
        public int MaterialID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int AuthorID { get; set; }
        [Required]
        public Author Author { get; set; }
        [Required]
        public int MaterialTypeID { get; set; }
        [Required]
        public MaterialType MaterialType { get; set; }
        [Required]
        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
        [Required]
        public DateTime PublishingDate { get; set; }
    }
}
