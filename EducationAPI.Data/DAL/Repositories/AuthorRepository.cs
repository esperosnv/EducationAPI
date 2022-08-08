using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EducationAPI.Data.Entities;
using EducationAPI.Data.DAL.Interfaces;
using EducationAPI.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EducationAPI.Data.DAL.Repositories
{
    public class AuthorRepository : IBaseRepository<Author>
    {
        private readonly EducationAPIContext _educationContext;
        public AuthorRepository()
        {
            _educationContext = new EducationAPIContext();
        }

        public void Add(Author entity)
        {
            _educationContext.Authors.Add(entity);
        }

        public void Delete(Author entity)
        {
            _educationContext.Authors.Remove(entity);
        }

        public async Task<List<Author>> GetAllAsync(string searchPhrase)
        {
            return await _educationContext.Authors.Include(a => a.Materials)
                                    .Where(a => searchPhrase == null || a.Name.ToLower().Contains(searchPhrase.ToLower()))
                                    .ToListAsync();
        }

        public async Task<Author> GetSingleAsync(Func<Author, bool> condition)
        {
            return await Task.FromResult(_educationContext.Authors.Include(a => a.Materials).FirstOrDefault(condition));
        }

        public async Task SaveAsync()
        {
            await _educationContext.SaveChangesAsync();
        }
    }
}
