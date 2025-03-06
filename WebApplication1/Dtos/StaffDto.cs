namespace WebApplication1.Dtos
{
    public class StaffDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
    }
}