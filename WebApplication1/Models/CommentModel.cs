using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models.Base;

namespace WebApplication1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? ToDoTaskId { get; set; }
        //navigation property
        public User User { get; set; } = default!;
        public ToDoTask? ToDoTask { get; set; } = default!;
    }
}