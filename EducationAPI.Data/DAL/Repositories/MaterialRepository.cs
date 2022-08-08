﻿using System;
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

        public async Task<List<Material>> GetAllAsync()
        {
            return await _educationContext.Materials.Include(m => m.Author).Include(m => m.MaterialType).ToListAsync();
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