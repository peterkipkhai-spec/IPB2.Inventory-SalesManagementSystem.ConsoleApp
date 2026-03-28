using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.MinimalApi1.Services
{
    public interface IReportService
    {
        Task<List<Product>> GetLowStockAsync();
        Task<object> GetProductSummaryAsync();
    }

    public class ReportService : IReportService
    {
        private readonly InventorySalesDbContext _db;

        public ReportService(InventorySalesDbContext db)
        {
            _db = db;
        }

        public async Task<List<Product>> GetLowStockAsync()
        {
            return await _db.Products.Where(x => x.QuantityInStock < 10).ToListAsync();
        }

        public async Task<object> GetProductSummaryAsync()
        {
            return await _db.SaleItems
                .GroupBy(x => x.ProductID)
                .Select(g => new
                {
                    ProductID = g.Key,
                    TotalQty = g.Sum(x => x.Quantity),
                    TotalSales = g.Sum(x => x.SubTotal)
                })
                .ToListAsync();
        }
    }
}
