using IPB2.Inventory_SalesManagementSystem.DB.Models;
using IPB2.Inventory_SalesManagementSystem.MVC.Features.Categories.Models;
using IPB2.Inventory_SalesManagementSystem.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.MVC.Features.Categories
{
    public class CategoryFeature
    {
        private readonly InventorySalesDbContext _db;

        public CategoryFeature()
        {
            _db = new InventorySalesDbContext();
        }

        public async Task<CategoryListResponse> GetListAsync()
        {
            var data = await _db.Categories.AsNoTracking().ToListAsync();
            return new CategoryListResponse
            {
                IsSuccess = true,
                Message = "Success",
                Data = data
            };
        }
        
        public async Task<CategoryResponse> GetByIdAsync(int id)
        {
            var category = await _db.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.CategoryId == id);
            if (category == null)
            {
                return new CategoryResponse
                {
                    IsSuccess = false,
                    Message = "Category not found",
                    Data = null
                };
            }
            
            return new CategoryResponse
            {
                IsSuccess = true,
                Message = "Success",
                Data = category
            };
        }

        public async Task<CategoryResponse> CreateAsync(CategoryRequest request)
        {
            var category = new Category
            {
                CategoryName = request.CategoryName,
                Description = request.Description
            };

            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return new CategoryResponse
            {
                IsSuccess = true,
                Message = "Category created successfully",
                Data = category
            };
        }

        public async Task<CategoryResponse> UpdateAsync(CategoryRequest request)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryId == request.CategoryId);
            if (category == null)
            {
                return new CategoryResponse
                {
                    IsSuccess = false,
                    Message = "Category not found",
                    Data = null
                };
            }

            category.CategoryName = request.CategoryName;
            category.Description = request.Description;

            _db.Categories.Update(category);
            await _db.SaveChangesAsync();

            return new CategoryResponse
            {
                IsSuccess = true,
                Message = "Category updated successfully",
                Data = category
            };
        }

        public async Task<BaseResponse<object>> DeleteAsync(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            if (category == null)
            {
                return new BaseResponse<object>
                {
                    IsSuccess = false,
                    Message = "Category not found"
                };
            }

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return new BaseResponse<object>
            {
                IsSuccess = true,
                Message = "Category deleted successfully"
            };
        }
    }
}
