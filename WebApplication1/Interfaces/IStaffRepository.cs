using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IStaffRepository
    {
        Task AddAsync(Staff staff);
        Task SaveChangeAsync();
        IQueryable<Staff> GetStaffQueryable(); 
    }
}