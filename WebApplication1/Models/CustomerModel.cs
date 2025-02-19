using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class Customer
    {
        public string Id { get; set; } = string.Empty;
        public CustomerTypes CustomerType { get; set; } = CustomerTypes.Regular;
        // nav property
        public User User { get; set; } = default!;
        public ICollection<ToDoTask> ToDoTasks { get; set; } = new List<ToDoTask>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}