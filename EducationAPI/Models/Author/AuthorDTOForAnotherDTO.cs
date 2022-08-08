namespace EducationAPI.Models.Author
{
    public class AuthorDTOForAnotherDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Materials { get; set; }
        public uint MaterialsCount { get; set; }
    }
}
