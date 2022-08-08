using EducationAPI.Models.Material;

namespace EducationAPI.Models.Author
{
    public class AuthorDTO
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MaterialsDTOForAnotherDTO> Materials { get; set; }
        public uint Counter { get; set; }
    }
}
