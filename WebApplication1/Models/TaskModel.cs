using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Enums;
using WebApplication1.Models.Base;

namespace WebApplication1.Models
{
    public class ToDoTask : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string SubDescription { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public ToDoTaskStatus Status { get; set; } = ToDoTaskStatus.Open;
        public PriorityStatus? Priority { get; set; }
        //navigation properties
        public Customer Customer { get; set; } = default!;
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}