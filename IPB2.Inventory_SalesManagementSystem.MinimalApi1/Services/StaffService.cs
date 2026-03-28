using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.MinimalApi1.Services
{
    public interface IStaffService
    {
        Task<List<Staff>> GetStaffsAsync();
        Task<Staff> CreateStaffAsync(Staff model);
        Task<Staff> UpdateStaffAsync(Staff model);
        Task<bool> DeleteStaffAsync(int id);
    }

    public class StaffService : IStaffService
    {
        private readonly InventorySalesDbContext _db;

        public StaffService(InventorySalesDbContext db)
        {
            _db = db;
        }

        public async Task<List<Staff>> GetStaffsAsync() => await _db.Staffs.AsNoTracking().ToListAsync();

        public async Task<Staff> CreateStaffAsync(Staff model)
        {
            _db.Staffs.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Staff> UpdateStaffAsync(Staff model)
        {
            _db.Staffs.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            var data = await _db.Staffs.FindAsync(id);
            if (data == null) return false;
            
            _db.Staffs.Remove(data);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
