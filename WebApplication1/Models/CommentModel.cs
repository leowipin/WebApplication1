using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models.Base;

namespace WebApplication1.Models
{
    public class Comment : AuditableEntity
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid ToDoTaskId { get; set; }
        //navigation property
        public Customer Customer { get; set; } = default!;
        public ToDoTask ToDoTask { get; set; } = default!;
    }
}