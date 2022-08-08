using EducationAPI.Models.Author;
using EducationAPI.Models.MaterialType;

namespace EducationAPI.Models.Material
{
    public class MaterialDTO
    {
        public int MaterialID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
      //  public AuthorDTO Author { get; set; }
       // public MaterialTypeDTO MaterialType { get; set; }
        //public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
        public DateTime PublishingDate { get; set; }
    }
}
