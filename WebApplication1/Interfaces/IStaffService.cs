using WebApplication1.Dtos;

namespace WebApplication1.Interfaces
{
    public interface IStaffService
    {
        Task<StaffDto> CreateStaffByIdAsync(StaffCreationDto staffCreationDto);
        Task<StaffDto?> GetStaffByIdAsync(Guid id);
    } 
}