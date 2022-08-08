using AutoMapper;
using EducationAPI.Data.DAL.Interfaces;
using EducationAPI.Data.Entities;
using EducationAPI.Models.MaterialType;
using EducationAPI.Data.Exceptions;
using EducationAPI.Models.Author;

namespace EducationAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Author> _authorRepository;

        public AuthorService(IMapper mapper, IBaseRepository<Author> authorRepository)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync(string searchPhrase)
        {
            var authors = await _authorRepository.GetAllAsync(searchPhrase);
            var authorsDTO = _mapper.Map<List<AuthorDTO>>(authors);
            return authorsDTO;
        }

        public async Task<AuthorDTO> GetAuthorByIDAsync(int authorID)
        {
            var author = await _authorRepository.GetSingleAsync(A => A.AuthorID == authorID);
            if (author is null) throw new ResourceNotFoundException($"Author with ID {authorID} not found");

            var authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

        public async Task CreateAuthorAsync(CreateAuthorDTO createAuthorDTO)
        {
            var newAuthor = _mapper.Map<Author>(createAuthorDTO);

            _authorRepository.Add(newAuthor);
            await _authorRepository.SaveAsync();
        }

        public async Task DeleteAuthorAsync(int authorID)
        {
            var author = await _authorRepository.GetSingleAsync(A => A.AuthorID == authorID);
            if (author is null) throw new ResourceNotFoundException($"Author with ID {authorID} not found");

            _authorRepository.Delete(author);
            await _authorRepository.SaveAsync();
        }

        public async Task UpdateAuthorAsync(UpdateAuthorDTO updateAuthorDTO, int authorID)
        {
            var author = await _authorRepository.GetSingleAsync(A => A.AuthorID == authorID);
            if (author is null) throw new ResourceNotFoundException($"Author with ID {authorID} not found");

            if (updateAuthorDTO.Description != null) author.Description = updateAuthorDTO.Description;
            if (updateAuthorDTO.Name != null) author.Name = updateAuthorDTO.Name;
            await _authorRepository.SaveAsync();
        }
    }
}
