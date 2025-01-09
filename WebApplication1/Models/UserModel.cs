using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Index(nameof(Email), IsUnique =true)]
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression("%[a-zA-Z+ÁÉÍÓÚáéíóúñÑ]%", ErrorMessage ="El nombre debe contener caracteres en español")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20, MinimumLength =2)]
        public string Username {  get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Range(0, 100)]
        public int Age { get; set; }
    }
}