using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string Position { get; set; } = string.Empty;
        //nav property
        public User User { get; set; } = default!;
    }
}