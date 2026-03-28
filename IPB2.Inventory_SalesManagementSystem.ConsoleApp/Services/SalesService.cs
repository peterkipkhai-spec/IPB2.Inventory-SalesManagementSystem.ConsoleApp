using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.ConsoleApp.Services
{
    public interface ISalesService
    {
        Task<(bool success, string message)> ProcessSaleAsync(int staffId, int productId, int qty);
    }

    public class SalesService : ISalesService
    {
        private readonly InventorySalesDbContext _db;

        public SalesService(InventorySalesDbContext db)
        {
            _db = db;
        }

        public async Task<(bool success, string message)> ProcessSaleAsync(int staffId, int productId, int qty)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.ProductID == productId);

            if (product == null || product.QuantityInStock < qty)
            {
                return (false, "Invalid product or insufficient stock");
            }

            decimal subtotal = (decimal)(qty * product.Price);

            var sale = new Sale
            {
                StaffID = staffId,
                TotalAmount = subtotal,
                SaleDate = DateTime.Now
            };

            _db.Sales.Add(sale);
            await _db.SaveChangesAsync();

            _db.SaleItems.Add(new SaleItem 
            { 
                SaleID = (int)sale.SaleID, 
                ProductID = productId, 
                Quantity = qty, 
                Price = (decimal)product.Price, 
                SubTotal = subtotal 
            });

            product.QuantityInStock -= qty;

            await _db.SaveChangesAsync();
            return (true, "Sale completed!");
        }
    }
}
