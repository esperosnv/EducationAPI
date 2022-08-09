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
    public class MaterialRepository : IBaseRepository<Material>
    {
        private readonly EducationAPIContext _educationContext;
        public MaterialRepository()
        {
            _educationContext = new EducationAPIContext();
        }

        public void Add(Material entity)
        {
            _educationContext.Materials.Add(entity);
        }

        public void Delete(Material entity)
        {
            _educationContext.Materials.Remove(entity);

        }

        public async Task<List<Material>> GetAllAsync(string? searchPhrase, string? direction)
        {
            var baseQuery = _educationContext.Materials.Include(m => m.Author).Include(m => m.MaterialType)
                                            .Where(a => searchPhrase == null || a.Title.ToLower().Contains(searchPhrase.ToLower()));

            switch (direction)
            {
                case "asc":
                    baseQuery = baseQuery.OrderBy(r => r.Title);
                    break;
                case "desc":
                    baseQuery = baseQuery.OrderByDescending(r => r.Title);
                    break;
            }

            return await baseQuery.ToListAsync();
        }

        public async Task<Material> GetSingleAsync(Func<Material, bool> condition)
        {
            return await Task.FromResult(_educationContext.Materials.Include(m => m.Author).Include(m => m.MaterialType).FirstOrDefault(condition));
        }

        public async Task SaveAsync()
        {
            await _educationContext.SaveChangesAsync();
        }
    }
}
