using IPB2.Inventory_SalesManagementSystem.DB.Models;

namespace IPB2.Inventory_SalesManagementSystem.MinimalApi1.Services
{
    public interface ISalesService
    {
        Task<(bool success, string message, Sale? sale)> CreateSaleAsync(int staffId, List<SaleItem> items);
    }

    public class SalesService : ISalesService
    {
        private readonly InventorySalesDbContext _db;

        public SalesService(InventorySalesDbContext db)
        {
            _db = db;
        }

        public async Task<(bool success, string message, Sale? sale)> CreateSaleAsync(int staffId, List<SaleItem> items)
        {
            decimal total = 0;
            foreach (var item in items)
            {
                var product = await _db.Products.FindAsync(item.ProductID);
                if (product == null || product.QuantityInStock < item.Quantity)
                    return (false, "Invalid product or insufficient stock", null);

                item.Price = (decimal)product.Price;
                item.SubTotal = item.Quantity * item.Price;
                total += (decimal)item.SubTotal;
                product.QuantityInStock -= item.Quantity;
            }

            var sale = new Sale { StaffID = staffId, TotalAmount = total, SaleDate = DateTime.Now };
            _db.Sales.Add(sale);
            await _db.SaveChangesAsync();

            foreach (var item in items)
            {
                item.SaleID = (int)sale.SaleID;
                _db.SaleItems.Add(item);
            }

            await _db.SaveChangesAsync();
            return (true, "Success", sale);
        }
    }
}
