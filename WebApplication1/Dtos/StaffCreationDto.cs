using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class StaffCreationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Position { get; set; } = string.Empty;
    }
}