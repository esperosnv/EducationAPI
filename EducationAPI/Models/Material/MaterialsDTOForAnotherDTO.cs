namespace EducationAPI.Models.Material
{
    public class MaterialsDTOForAnotherDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        //  public AuthorDTO Author { get; set; }
        // public MaterialTypeDTO MaterialType { get; set; }
        //public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
        public DateTime PublishingDate { get; set; }
    }
}
