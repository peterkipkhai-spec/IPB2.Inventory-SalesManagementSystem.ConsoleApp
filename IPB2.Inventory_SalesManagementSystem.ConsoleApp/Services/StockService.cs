using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.ConsoleApp.Services
{
    public interface IStockService
    {
        Task<(bool success, string message)> UpdateStockAsync(int productId, int qty, string type);
    }

    public class StockService : IStockService
    {
        private readonly InventorySalesDbContext _db;

        public StockService(InventorySalesDbContext db)
        {
            _db = db;
        }

        public async Task<(bool success, string message)> UpdateStockAsync(int productId, int qty, string type)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.ProductID == productId);

            if (product == null)
            {
                return (false, "Product not found");
            }

            if (type == "IN")
            {
                product.QuantityInStock += qty;
            }
            else if (type == "OUT")
            {
                if (product.QuantityInStock < qty)
                {
                    return (false, "Not enough stock!");
                }
                product.QuantityInStock -= qty;
            }
            else
            {
                return (false, "Invalid type!");
            }

            _db.StockTransactions.Add(new StockTransaction
            {
                ProductID = productId,
                Quantity = qty,
                TransactionType = type
            });

            await _db.SaveChangesAsync();
            return (true, "Stock updated!");
        }
    }
}
