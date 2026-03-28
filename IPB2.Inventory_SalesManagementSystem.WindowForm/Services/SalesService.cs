using IPB2.Inventory_SalesManagementSystem.DB.Models;
using IPB2.Inventory_SalesManagementSystem.WindowForm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Services
{
    public class SalesService : ISalesService
    {
        public void CreateSale(int staffId, List<SaleItem> items)
        {
            using var db = AppDbContextFactory.Create();

            var sale = new Sale
            {
                StaffID = staffId,
                SaleDate = DateTime.Now,
                TotalAmount = items.Sum(x => x.SubTotal)
            };

            db.Sales.Add(sale);
            db.SaveChanges();

            foreach (var item in items)
            {
                item.SaleID = (int)sale.SaleID;

                var product = db.Products.Find(item.ProductID);
                product.QuantityInStock -= item.Quantity;

                db.SaleItems.Add(item);
            }

            db.SaveChanges();
        }
    }
}
