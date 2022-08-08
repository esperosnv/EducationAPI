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
    public class MaterialTypeRepository : IBaseRepository<MaterialType>
    {
        private readonly EducationAPIContext _educationContext;
        public MaterialTypeRepository()
        {
            _educationContext = new EducationAPIContext();
        }

        public void Add(MaterialType entity)
        {
            _educationContext.MaterialTypes.Add(entity);
        }

        public void Delete(MaterialType entity)
        {
            _educationContext.MaterialTypes.Remove(entity);
        }

        public async Task<List<MaterialType>> GetAllAsync(string searchPhrase)
        {
            return await _educationContext.MaterialTypes
                                            .Where(a => searchPhrase == null || a.Name.ToLower().Contains(searchPhrase.ToLower())).ToListAsync();
        }

        public async Task<MaterialType> GetSingleAsync(Func<MaterialType, bool> condition)
        {
            return await Task.FromResult(_educationContext.MaterialTypes.FirstOrDefault(condition));
        }

        public async Task SaveAsync()
        {
            await _educationContext.SaveChangesAsync();
        }
    }
}
