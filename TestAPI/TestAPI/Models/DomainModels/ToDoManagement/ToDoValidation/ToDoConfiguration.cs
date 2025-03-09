using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAPI.Models.DomainModels.ToDoManagement.ToDoModel;

namespace TestAPI.Models.DomainModels.ToDoManagement.ToDoValidation
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Title)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired();
        }
    }
}
