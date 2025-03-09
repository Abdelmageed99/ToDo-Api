using TestAPI.Models.CustomModels;

namespace TestAPI.Services.ToDoService.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(RequestModel model);
        Task<T> GetByIdAsync(int Id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(int Id, T entity);
        Task<T> DeleteAsync(int Id);


    }
}
