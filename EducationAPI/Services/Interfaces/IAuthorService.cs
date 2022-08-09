using EducationAPI.Models.Author;

namespace EducationAPI.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync(string? searchPhrase, string? direction);
        Task<AuthorDTO> GetAuthorByIDAsync(int authorID);
        Task<AuthorDTO> CreateAuthorAsync(CreateAuthorDTO createAuthorDTO);
        Task DeleteAuthorAsync(int authorID);
        Task<AuthorDTO> UpdateAuthorAsync(UpdateAuthorDTO updateAuthorDTO, int authorID);
        Task<AuthorDTO> PutAuthorAsync(PutAuthorDTO putAuthorDTO, int authorID);
        Task<AuthorDTO> GetMostProductiveAuthorsAsync();
    }
}