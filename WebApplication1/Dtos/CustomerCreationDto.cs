using System.ComponentModel.DataAnnotations;
using WebApplication1.Enums;

namespace WebApplication1.Dtos
{
    public class CustomerCreationDto
    {
        [Required]
        public string Email {  get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string NickName { get; set; } = string.Empty;
    }
}