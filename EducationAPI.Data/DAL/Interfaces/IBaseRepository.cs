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
