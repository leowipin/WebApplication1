using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models.Base;

namespace WebApplication1.Models
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        //navigation properties
        public ICollection<ToDoTask> ToDoTasks { get; set; } = new List<ToDoTask>();
        public User User { get; set; } = default!;

    }
}