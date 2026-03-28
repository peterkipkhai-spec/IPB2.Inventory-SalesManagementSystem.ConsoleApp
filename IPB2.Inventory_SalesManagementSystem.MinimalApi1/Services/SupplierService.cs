using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.MinimalApi1.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly InventorySalesDbContext _db;

        public SupplierService(InventorySalesDbContext db)
        {
            _db = db;
        }

        public async Task<object> GetSuppliersAsync(int pageNo, int pageSize)
        {
            var query = _db.Suppliers.AsNoTracking().OrderBy(x => x.SupplierID);
            var totalCount = await query.CountAsync();
            var data = await query.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
            
            return new
            {
                PageNo = pageNo,
                PageSize = pageSize,
                TotalCount = totalCount,
                PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
                Data = data
            };
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier model)
        {
            _db.Suppliers.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Supplier> UpdateSupplierAsync(Supplier model)
        {
            _db.Suppliers.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var data = await _db.Suppliers.FindAsync(id);
            if (data == null) return false;
            
            _db.Suppliers.Remove(data);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
