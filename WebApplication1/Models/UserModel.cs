using Microsoft.AspNetCore.Identity;
using WebApplication1.Models.Base;

namespace WebApplication1.Models
{
    public class User : IdentityUser, IAuditableEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        // nav property
        public Customer? Customer { get; set; }
        public Staff? Staff { get; set; }
    }
    
}