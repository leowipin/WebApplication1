using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
    }
}