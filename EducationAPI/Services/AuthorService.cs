using AutoMapper;
using EducationAPI.Data.DAL.Interfaces;
using EducationAPI.Data.Entities;
using EducationAPI.Models.MaterialType;
using EducationAPI.Data.Exceptions;
using EducationAPI.Models.Author;
using EducationAPI.Models;
using EducationAPI.Data.Entities;



namespace EducationAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Author> _authorRepository;
        private readonly ILogger<AuthorService> _logger;


        public AuthorService(IMapper mapper, IBaseRepository<Author> authorRepository, ILogger<AuthorService> logger)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync(string? searchPhrase, string? direction)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to get all authors");

            if (direction != null) direction = direction.ToLower();
            if (direction != null && direction != "asc" && direction != "desc") throw new ResourceNotFoundException("Not correct direction");

            var authors = await _authorRepository.GetAllAsync(searchPhrase, direction);
            var authorsDTO = _mapper.Map<List<AuthorDTO>>(authors);
            return authorsDTO;
        }

        public async Task<AuthorDTO> GetAuthorByIDAsync(int authorID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to get author with id {authorID}");

            var author = await _authorRepository.GetSingleAsync(A => A.AuthorID == authorID);
            if (author is null) throw new ResourceNotFoundException($"Author with ID {authorID} not found");

            var authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

        public async Task<AuthorDTO> CreateAuthorAsync(CreateAuthorDTO createAuthorDTO)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to create a new author");

            var newAuthor = _mapper.Map<Author>(createAuthorDTO);

            _authorRepository.Add(newAuthor);
            await _authorRepository.SaveAsync();

            return await GetAuthorByIDAsync(newAuthor.AuthorID);
        }

        public async Task DeleteAuthorAsync(int authorID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to delete an author with id {authorID}");

            var author = await _authorRepository.GetSingleAsync(A => A.AuthorID == authorID);
            if (author is null) throw new ResourceNotFoundException($"Author with ID {authorID} not found");

            _authorRepository.Delete(author);
            await _authorRepository.SaveAsync();
        }

        public async Task<AuthorDTO> UpdateAuthorAsync(UpdateAuthorDTO updateAuthorDTO, int authorID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Patch request to update author with id {authorID}");

            var author = await _authorRepository.GetSingleAsync(A => A.AuthorID == authorID);
            if (author is null) throw new ResourceNotFoundException($"Author with ID {authorID} not found");

            if (updateAuthorDTO.Description != null) author.Description = updateAuthorDTO.Description;
            if (updateAuthorDTO.Name != null) author.Name = updateAuthorDTO.Name;

            await _authorRepository.SaveAsync();

            return await GetAuthorByIDAsync(authorID);
        }

        public async Task<AuthorDTO> PutAuthorAsync(PutAuthorDTO putAuthorDTO, int authorID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Put request to update author with id {authorID}");

            var author = await _authorRepository.GetSingleAsync(A => A.AuthorID == authorID);
            if (author is null) throw new ResourceNotFoundException($"Author with ID {authorID} not found");
            author.Description = putAuthorDTO.Description;
            author.Name = putAuthorDTO.Name;

            await _authorRepository.SaveAsync();
            return await GetAuthorByIDAsync(authorID);

        }
    }
}
