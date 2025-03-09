using Microsoft.EntityFrameworkCore;
using TestAPI.Models.DomainModels.ToDoManagement.ToDoValidation;

namespace TestAPI.Models.DomainModels.ToDoManagement.ToDoModel
{
    [EntityTypeConfiguration(typeof(ToDoConfiguration))]
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

}
