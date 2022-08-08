﻿using EducationAPI.Models.Author;
using EducationAPI.Models;
using EducationAPI.Data.Entities;



namespace EducationAPI.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync(string? searchPhrase, string? direction);
        Task<AuthorDTO> GetAuthorByIDAsync(int authorID);
        Task CreateAuthorAsync(CreateAuthorDTO createAuthorDTO);
        Task DeleteAuthorAsync(int authorID);
        Task UpdateAuthorAsync(UpdateAuthorDTO updateAuthorDTO, int authorID);
    }
}