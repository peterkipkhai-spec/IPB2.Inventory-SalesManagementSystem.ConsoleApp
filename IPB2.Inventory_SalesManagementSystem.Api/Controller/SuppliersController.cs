using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly InventorySalesDbContext _db;

        public object PageNo { get; private set; }
        public object PageSize { get; private set; }
        public object TotalCount { get; private set; }

        public SuppliersController()
        {
            _db = new InventorySalesDbContext();
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList(int pageNo = 1, int pageSize = 10)
        {
            var query = _db.Suppliers.AsNoTracking().OrderBy(x => x.SupplierId);

            var totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                PageNo,
                PageSize,
                TotalCount,
                PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
                Data = data
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplier model)
        {
            _db.Suppliers.Add(model);
            await _db.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Supplier model)
        {
            _db.Suppliers.Update(model);
            await _db.SaveChangesAsync();
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _db.Suppliers.FindAsync(id);
            if (data == null) return NotFound();

            _db.Suppliers.Remove(data);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
