namespace WebApplication1.Models
{
    public class Customer
    {
        public string Id { get; set; } = string.Empty;
        public bool IsVip { get; set; } = false;
        public DateTime? VipExpired { get; set; } // como hago el constraint aqui con IsVip
        // nav property
        public User User { get; set; } = default!;
        public ICollection<ToDoTask> ToDoTasks { get; set; } = new List<ToDoTask>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}