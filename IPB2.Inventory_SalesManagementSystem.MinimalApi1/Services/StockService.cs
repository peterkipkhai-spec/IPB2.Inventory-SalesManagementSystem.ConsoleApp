using IPB2.Inventory_SalesManagementSystem.DB.Models;

namespace IPB2.Inventory_SalesManagementSystem.MinimalApi1.Services
{
    public interface IStockService
    {
        Task<(bool success, string message, Product? product)> StockInAsync(int productId, int qty);
        Task<(bool success, string message, Product? product)> StockOutAsync(int productId, int qty);
    }

    public class StockService : IStockService
    {
        private readonly InventorySalesDbContext _db;

        public StockService(InventorySalesDbContext db)
        {
            _db = db;
        }

        public async Task<(bool success, string message, Product? product)> StockInAsync(int productId, int qty)
        {
            var product = await _db.Products.FindAsync(productId);
            if (product == null) return (false, "Product not found", null);
            
            product.QuantityInStock += qty;
            _db.StockTransactions.Add(new StockTransaction { ProductID = productId, Quantity = qty, TransactionType = "IN" });
            await _db.SaveChangesAsync();
            
            return (true, "Success", product);
        }

        public async Task<(bool success, string message, Product? product)> StockOutAsync(int productId, int qty)
        {
            var product = await _db.Products.FindAsync(productId);
            if (product == null) return (false, "Product not found", null);
            if (product.QuantityInStock < qty) return (false, "Not enough stock", null);

            product.QuantityInStock -= qty;
            _db.StockTransactions.Add(new StockTransaction { ProductID = productId, Quantity = qty, TransactionType = "OUT" });
            await _db.SaveChangesAsync();
            
            return (true, "Success", product);
        }
    }
}
