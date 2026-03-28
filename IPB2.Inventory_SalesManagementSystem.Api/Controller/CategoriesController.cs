using IPB2.Inventory_SalesManagementSystem.Api.Models;
using IPB2.Inventory_SalesManagementSystem.Api.Models.Categories;
using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly InventorySalesDbContext _db;

        public CategoriesController()
        {
            _db = new InventorySalesDbContext();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _db.Categories.ToListAsync();
            return Ok(new CategoryListResponse
            {
                IsSuccess = true,
                Message = "Success",
                Data = data
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            _db.Categories.Add(model);
            await _db.SaveChangesAsync();
            return Ok(new CategoryResponse
            {
                IsSuccess = true,
                Message = "Category created successfully",
                Data = model
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category model)
        {
            _db.Categories.Update(model);
            await _db.SaveChangesAsync();
            return Ok(new CategoryResponse
            {
                IsSuccess = true,
                Message = "Category updated successfully",
                Data = model
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _db.Categories.FindAsync(id);
            if (data == null)
            {
                return NotFound(new BaseResponse<object>
                {
                    IsSuccess = false,
                    Message = "Category not found"
                });
            }

            _db.Categories.Remove(data);
            await _db.SaveChangesAsync();
            return Ok(new BaseResponse<object>
            {
                IsSuccess = true,
                Message = "Category deleted successfully"
            });
        }
    }
}
