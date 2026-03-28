using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPB2.Inventory_SalesManagementSystem.DB.Models;
using IPB2.Inventory_SalesManagementSystem.WindowForm.Data;
using Microsoft.EntityFrameworkCore;

    
namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetAll()
        {
            using var db = AppDbContextFactory.Create();
            return db.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .ToList();
        }

        public void Add(Product p)
        {
            using var db = AppDbContextFactory.Create();
            db.Products.Add(p);
            db.SaveChanges();
        }

        public void Update(Product p)
        {
            using var db = AppDbContextFactory.Create();
            db.Products.Update(p);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            using var db = AppDbContextFactory.Create();
            var p = db.Products.Find(id);
            if (p != null)
            {
                db.Products.Remove(p);
                db.SaveChanges();
            }
        }
    }
}
