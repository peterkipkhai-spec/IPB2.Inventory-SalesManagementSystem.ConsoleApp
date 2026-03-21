using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPB2.Inventory_SalesManagementSystem.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly InventorySalesDbContext _db;

        public StockController()
        {
            _db = new InventorySalesDbContext();
        }

        [HttpPost("stock-in")]
        public async Task<IActionResult> StockIn(int productId, int qty)
        {
            var product = await _db.Products.FindAsync(productId);
            if (product == null) return NotFound("Product not found");

            product.QuantityInStock += qty;

            _db.StockTransactions.Add(new StockTransaction
            {
                ProductId = productId,
                Quantity = qty,
                TransactionType = "IN"
            });

            await _db.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPost("stock-out")]
        public async Task<IActionResult> StockOut(int productId, int qty)
        {
            var product = await _db.Products.FindAsync(productId);
            if (product == null) return NotFound();

            if (product.QuantityInStock < qty)
                return BadRequest("Not enough stock");

            product.QuantityInStock -= qty;

            _db.StockTransactions.Add(new StockTransaction
            {
                ProductId = productId,
                Quantity = qty,
                TransactionType = "OUT"
            });

            await _db.SaveChangesAsync();
            return Ok(product);
        }
    }
}
