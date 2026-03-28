using IPB2.Inventory_SalesManagementSystem.DB.Models;
using IPB2.Inventory_SalesManagementSystem.WindowForm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Services
{
    public class CategoryService : ICategoryService
    {
        public List<Category> GetAll()
        {
            using var db = AppDbContextFactory.Create();
            return db.Categories.ToList();
        }

        public void Add(Category c)
        {
            using var db = AppDbContextFactory.Create();
            db.Categories.Add(c);
            db.SaveChanges();
        }
    }
}
