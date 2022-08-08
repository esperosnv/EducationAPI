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

        public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            var authorsDTO = _mapper.Map<List<AuthorDTO>>(authors);
            return authorsDTO;
        }
    }
}
