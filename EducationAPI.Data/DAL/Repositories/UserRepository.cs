using EducationAPI.Data.Context;
using EducationAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using EducationAPI.Data.DAL.Interfaces;

namespace EducationAPI.Data.DAL.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly EducationAPIContext _educationContext;
        public UserRepository()
        {
            _educationContext = new EducationAPIContext();
        }

        public void Add(User entity)
        {
            _educationContext.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            _educationContext.Users.Remove(entity);
        }

        public async Task<List<User>> GetAllAsync(string? searchPhrase, string? direction)
        {
            return await _educationContext.Users.ToListAsync();
        }

        public async Task<User> GetSingleAsync(Func<User, bool> condition)
        {
            return await Task.FromResult(_educationContext.Users.FirstOrDefault(condition));
        }

        public async Task SaveAsync()
        {
            await _educationContext.SaveChangesAsync();
        }
    }
}
