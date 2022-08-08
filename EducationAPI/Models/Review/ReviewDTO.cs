using EducationAPI.Models.Material;


namespace EducationAPI.Models.Review
{
    public class ReviewDTO
    {
        public int ReviewID { get; set; }
        public string Text { get; set; }
        public string Material { get; set; }
        public uint Rating { get; set; }
    }
}
