using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly InventorySalesDbContext _db;

        public ProductsController()
        {
            _db = new InventorySalesDbContext();
        }

        public object PageNo { get; private set; }
        public object PageSize { get; private set; }
        public object TotalCount { get; private set; }

        // Basic List
        [HttpGet]
        public async Task<IActionResult> GetAsync(int pageNo, int pageSize)
        {
            var lst = await _db.Products
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(lst);
        }

        // Full Pagination
        [HttpGet("List")]
        public async Task<IActionResult> GetList(int pageNo = 1, int pageSize = 10)
        {
            if (pageNo <= 0) pageNo = 1;
            if (pageSize <= 0) pageSize = 10;

            var query = _db.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .AsNoTracking()
                .OrderBy(x => x.ProductId);

            var totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new
                {
                    x.ProductId,
                    x.ProductName,
                    Category = x.Category.CategoryName,
                    Supplier = x.Supplier.CompanyName,
                    x.Price,
                    x.QuantityInStock
                })
                .ToListAsync();

            return Ok(new
            {
                PageNo = pageNo,
                PageSize = pageSize,
                TotalCount = totalCount,
                PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
                Data = data
            });
        }

        // Search
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string? keyword = null, int pageNo = 1, int pageSize = 10)
        {
            var query = _db.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();

                query = query.Where(x =>
                    x.ProductName.Contains(keyword));
            }

            query = query.OrderBy(x => x.ProductId);

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
    }
}