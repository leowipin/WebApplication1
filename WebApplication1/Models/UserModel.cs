using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    [Index(nameof(Email), IsUnique =true)]
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [MinLength(2, ErrorMessage ="El nombre debe contener mas de 2 caracteres")]
        [MaxLength(20, ErrorMessage = "El nombre debe contener mas de 20 caracteres")]
        [RegularExpression(@"[a-zA-Z]+$", ErrorMessage ="El nombre solo debe contener letras")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }
}