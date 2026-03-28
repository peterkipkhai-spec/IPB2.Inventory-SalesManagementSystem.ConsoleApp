using IPB2.Inventory_SalesManagementSystem.Api.Models;
using IPB2.Inventory_SalesManagementSystem.Api.Models.Staffs;
using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly InventorySalesDbContext _db;

        public StaffsController()
        {
            _db = new InventorySalesDbContext();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _db.Staffs.ToListAsync();
            return Ok(new StaffListResponse
            {
                IsSuccess = true,
                Message = "Success",
                Data = data
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Staff model)
        {
            _db.Staffs.Add(model);
            await _db.SaveChangesAsync();
            return Ok(new StaffResponse
            {
                IsSuccess = true,
                Message = "Staff created successfully",
                Data = model
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(Staff model)
        {
            _db.Staffs.Update(model);
            await _db.SaveChangesAsync();
            return Ok(new StaffResponse
            {
                IsSuccess = true,
                Message = "Staff updated successfully",
                Data = model
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _db.Staffs.FindAsync(id);
            if (data == null)
            {
                return NotFound(new BaseResponse<object>
                {
                    IsSuccess = false,
                    Message = "Staff not found"
                });
            }

            _db.Staffs.Remove(data);
            await _db.SaveChangesAsync();
            return Ok(new BaseResponse<object>
            {
                IsSuccess = true,
                Message = "Staff deleted successfully"
            });
        }
    }
}
