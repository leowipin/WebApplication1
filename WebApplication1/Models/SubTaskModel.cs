using WebApplication1.Enums;
using WebApplication1.Models.Base;

namespace WebApplication1.Models
{
    public class SubTask : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid ToDoTaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public ToDoTaskStatus Status { get; set; } = ToDoTaskStatus.Open;
        //navigation property
        public ToDoTask ToDoTask { get; set; } = default!;
    }
}