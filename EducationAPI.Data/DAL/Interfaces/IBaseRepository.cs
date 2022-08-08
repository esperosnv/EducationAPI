using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EducationAPI.Data.Entities;

namespace EducationAPI.Data.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(string? searchPhrase, string? direction);
        Task<T> GetSingleAsync(Func<T, bool> condition);
        void Add(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
