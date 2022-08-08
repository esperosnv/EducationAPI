using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationAPI.Data.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetSingleAsync(Func<T, bool> condition);
        public void Add(T entity);
        public void Delete(T entity);
        public Task SaveAsync(); 
    }
}
