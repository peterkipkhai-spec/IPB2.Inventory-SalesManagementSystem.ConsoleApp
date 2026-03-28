using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.ConsoleApp.Services
{
    public interface IReportService
    {
        Task<List<Product>> GetLowStockProductsAsync(int threshold = 10);
    }

    public class ReportService : IReportService
    {
        private readonly InventorySalesDbContext _db;

        public ReportService(InventorySalesDbContext db)
        {
            _db = db;
        }

        public async Task<List<Product>> GetLowStockProductsAsync(int threshold = 10)
        {
            return await _db.Products
                .Where(x => x.QuantityInStock < threshold)
                .ToListAsync();
        }
    }
}
