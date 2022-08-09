using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Data.Entities
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IEnumerable<Material> Materials { get; set; }

        public Author()
        {
            Materials = new List<Material>();
        }
    }
}
