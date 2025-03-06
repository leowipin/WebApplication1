using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class StaffRepository (ApplicationDbContext context) : IStaffRepository
    {
        public ApplicationDbContext _context = context;

        public async Task AddAsync(Staff staff)
        {
            await _context.Staffs.AddAsync(staff);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable<Staff> GetStaffQueryable()
        {
            return _context.Staffs.AsQueryable();
        }
    }
}