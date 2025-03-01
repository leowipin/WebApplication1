using WebApplication1.Enums;

namespace WebApplication1.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public CustomerTypes CustomerType { get; set; } = CustomerTypes.Regular;
        public string NickName { get; set; } = string.Empty;
        // nav property
        public User User { get; set; } = default!;
        public ICollection<ToDoTask> ToDoTasks { get; set; } = new List<ToDoTask>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}