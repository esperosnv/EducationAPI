using EducationAPI.Models.Author;

namespace EducationAPI.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync();
        Task<AuthorDTO> GetAuthorByIDAsync(int authorID);
        Task CreateAuthorAsync(CreateAuthorDTO createAuthorDTO);
        Task DeleteAuthorAsync(int authorID);
    }
}