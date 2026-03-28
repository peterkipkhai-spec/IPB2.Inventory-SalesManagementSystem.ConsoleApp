using IPB2.Inventory_SalesManagementSystem.DB.Models;
using IPB2.Inventory_SalesManagementSystem.WindowForm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Services
{
    public class StockService : IStockService
    {
        public void StockIn(int productId, int qty)
        {
            using var db = AppDbContextFactory.Create();

            var product = db.Products.Find(productId);
            product.QuantityInStock += qty;

            db.StockTransactions.Add(new StockTransaction
            {
                ProductID = productId,
                Quantity = qty,
                TransactionType = "IN"
            });

            db.SaveChanges();
        }

        public void StockOut(int productId, int qty)
        {
            using var db = AppDbContextFactory.Create();

            var product = db.Products.Find(productId);

            if (product.QuantityInStock < qty)
                throw new Exception("Not enough stock");

            product.QuantityInStock -= qty;

            db.StockTransactions.Add(new StockTransaction
            {
                ProductID = productId,
                Quantity = qty,
                TransactionType = "OUT"
            });

            db.SaveChanges();
        }
    }
}
