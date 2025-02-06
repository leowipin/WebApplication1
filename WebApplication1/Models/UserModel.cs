using Microsoft.AspNetCore.Identity;
using WebApplication1.Models.Base;

namespace WebApplication1.Models
{
    public class User : IdentityUser, IAuditableEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<ToDoTask> ToDoTasks { get; set; } = new List<ToDoTask>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
    
}