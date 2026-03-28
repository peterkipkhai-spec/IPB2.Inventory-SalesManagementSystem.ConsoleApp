using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.ConsoleApp.Services
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetSuppliersAsync();
    }

    public class SupplierService : ISupplierService
    {
        private readonly InventorySalesDbContext _db;

        public SupplierService(InventorySalesDbContext db)
        {
            _db = db;
        }

        public async Task<List<Supplier>> GetSuppliersAsync()
        {
            return await _db.Suppliers.ToListAsync();
        }
    }
}
