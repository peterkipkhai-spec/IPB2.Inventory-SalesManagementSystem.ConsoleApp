using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.MinimalApi1.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> CreateCategoryAsync(Category model);
        Task<Category> UpdateCategoryAsync(Category model);
        Task<bool> DeleteCategoryAsync(int id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly InventorySalesDbContext _db;

        public CategoryService(InventorySalesDbContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetCategoriesAsync() => await _db.Categories.AsNoTracking().ToListAsync();

        public async Task<Category> CreateCategoryAsync(Category model)
        {
            _db.Categories.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Category> UpdateCategoryAsync(Category model)
        {
            _db.Categories.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var data = await _db.Categories.FindAsync(id);
            if (data == null) return false;
            
            _db.Categories.Remove(data);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
