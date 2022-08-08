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
    public class ReviewRepository : IBaseRepository<Review>
    {
        private readonly EducationAPIContext _educationContext;
        public ReviewRepository()
        {
            _educationContext = new EducationAPIContext();
        }

        public void Add(Review entity)
        {
            _educationContext.Reviews.Add(entity);
        }

        public void Delete(Review entity)
        {
            _educationContext.Reviews.Remove(entity);
        }

        public async Task<List<Review>> GetAllAsync(string? searchPhrase, string? direction)
        {
            var baseQuery = _educationContext.Reviews.Include(a => a.Material)
                                                .Where(a => searchPhrase == null || a.Text.ToLower().Contains(searchPhrase.ToLower()));
            switch (direction)
            {
                case "ASC":
                    baseQuery = baseQuery.OrderBy(r => r.Rating);
                    break;
                case "DESC":
                    baseQuery = baseQuery.OrderByDescending(r => r.Rating);
                    break;
            }

            return await baseQuery.ToListAsync();
        }

        public async Task<Review> GetSingleAsync(Func<Review, bool> condition)
        {
            return await Task.FromResult(_educationContext.Reviews.Include(a => a.Material).FirstOrDefault(condition));
        }

        public async Task SaveAsync()
        {
            await _educationContext.SaveChangesAsync();
        }
    }
}
