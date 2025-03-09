using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models.DomainModels.ToDoManagement.ToDoModel;
using TestAPI.Models.DomainModels.UserManagement.UserModel;

namespace TestAPI.Data
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public DbSet<ToDoItem> toDoItems {  get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
    }
}
