using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.ConsoleApp.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
    }

    public class ProductService : IProductService
    {
        private readonly InventorySalesDbContext _db;

        public ProductService(InventorySalesDbContext db)
        {
            _db = db;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _db.Products.ToListAsync();
        }
    }
}
