using TestAPI.Models.CustomModels;
using TestAPI.Models.DomainModels.ToDoManagement.ToDoDTO;
using TestAPI.Models.DomainModels.ToDoManagement.ToDoModel;

namespace TestAPI.Services.ToDoService.Interfaces
{
    public interface ITODoService
    {
        Task<ResponseModel> GetAllAsync(RequestModel model);
        Task<ResponseModel> GetByIdAsync(int Id);
        Task<ResponseModel> AddAsync(CreateToDo entity);
        Task<ResponseModel> UpdateAsync(int Id, UpdateToDo entity);
        Task<ResponseModel> DeleteAsync(int Id);
    }
}
