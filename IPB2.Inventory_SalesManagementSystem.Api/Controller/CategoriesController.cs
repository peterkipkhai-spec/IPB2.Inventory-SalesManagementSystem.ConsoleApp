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
            return Ok(await _db.Categories.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            _db.Categories.Add(model);
            await _db.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category model)
        {
            _db.Categories.Update(model);
            await _db.SaveChangesAsync();
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _db.Categories.FindAsync(id);
            if (data == null) return NotFound();

            _db.Categories.Remove(data);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
