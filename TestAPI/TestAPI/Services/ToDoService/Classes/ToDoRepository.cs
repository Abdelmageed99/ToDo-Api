
using Microsoft.EntityFrameworkCore;
using TestAPI.Data;
using TestAPI.Models.CustomModels;
using TestAPI.Models.DomainModels.ToDoManagement.ToDoModel;
using TestAPI.Services.ToDoService.Interfaces;

namespace TestAPI.Services.ToDoService.Classes
{
    public class ToDoRepository : IRepository<ToDoItem>
    {
        private readonly ApplicationDbContext _context;

        public ToDoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoItem>> GetAllAsync(RequestModel model)
        {
            return await _context.toDoItems.Skip((model.PageIndex-1) * model.PageSize).Take(model.PageSize).ToListAsync();
        }

        public async Task<ToDoItem> GetByIdAsync(int Id)
        {
            return await _context.toDoItems.FindAsync(Id);
        }
        public async Task<ToDoItem> AddAsync(ToDoItem entity)
        {
            _context.toDoItems.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<ToDoItem> DeleteAsync(int Id)
        {
            var user = await _context.toDoItems.FindAsync(Id);
            if (user != null)
            {
                _context.toDoItems.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }

            return user;
        }

        public async Task<ToDoItem> UpdateAsync(int Id, ToDoItem entity)
        {

            ToDoItem? existingItem = await _context.toDoItems.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingItem != null)
            {
                existingItem.Title = entity.Title;
                existingItem.Description = entity.Description;
                await _context.SaveChangesAsync();

                return existingItem;
            }

            return existingItem;


        }
    }
}
