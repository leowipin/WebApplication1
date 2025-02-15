using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Staff
    {
        public string Id { get; set; } = string.Empty;
        public string StaffId { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        //nav property
        public User User { get; set; } = default!;
    }
}