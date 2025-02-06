using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Configurations
{
    public class ToDoTaskConfiguration : IEntityTypeConfiguration<ToDoTask>
    {
        public void Configure(EntityTypeBuilder<ToDoTask> entity)
        {
            // properties
            entity.Property(x => x.Title).HasMaxLength(100);
            entity.Property(x => x.Description).HasMaxLength(500);
            entity.Property(x => x.Status).HasConversion<string>();
            entity.Property(x => x.Priority).HasConversion<string>();
            // relationships
            entity.HasOne(toDoTask => toDoTask.User)
                .WithMany(user => user.ToDoTasks)
                .HasForeignKey(toDoTask => toDoTask.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(t => t.Categories)
                .WithMany(c => c.ToDoTasks)
                .UsingEntity(j => j.ToTable("TaskCategory"));
            entity.HasMany(toDoTask => toDoTask.SubTasks)
                .WithOne(subTask => subTask.ToDoTask)
                .HasForeignKey(subTask => subTask.ToDoTaskId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(toDoTask => toDoTask.Comments)
                .WithOne(comment => comment.ToDoTask)
                .HasForeignKey(comment => comment.ToDoTaskId)
                .OnDelete(DeleteBehavior.Restrict);
            // indexes
            //entity.HasIndex(toDoTask => toDoTask.UserId);
        }
    }
}