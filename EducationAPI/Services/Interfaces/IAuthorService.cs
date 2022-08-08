using EducationAPI.Models.Author;

namespace EducationAPI.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync();
    }
}