namespace EducationAPI.Models.Material
{
    public class CreateMaterialDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int AuthorID { get; set; }
        public int MaterialTypeID { get; set; }
        public DateTime PublishingDate { get; set; }
    }
}
