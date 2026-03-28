using IPB2.Inventory_SalesManagementSystem.Api.Models;
using IPB2.Inventory_SalesManagementSystem.Api.Models.Stock;
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
        public async Task<IActionResult> StockIn(StockRequest request)
        {
            var product = await _db.Products.FindAsync(request.ProductId);
            if (product == null)
            {
                return NotFound(new StockResponse
                {
                    IsSuccess = false,
                    Message = "Product not found"
                });
            }

            product.QuantityInStock += request.Qty;

            _db.StockTransactions.Add(new StockTransaction
            {
                ProductId = request.ProductId,
                Quantity = request.Qty,
                TransactionType = "IN"
            });

            await _db.SaveChangesAsync();
            return Ok(new StockResponse
            {
                IsSuccess = true,
                Message = "Stock added successfully",
                Data = product
            });
        }

        [HttpPost("stock-out")]
        public async Task<IActionResult> StockOut(StockRequest request)
        {
            var product = await _db.Products.FindAsync(request.ProductId);
            if (product == null)
            {
                return NotFound(new StockResponse
                {
                    IsSuccess = false,
                    Message = "Product not found"
                });
            }

            if (product.QuantityInStock < request.Qty)
            {
                return BadRequest(new StockResponse
                {
                    IsSuccess = false,
                    Message = "Not enough stock"
                });
            }

            product.QuantityInStock -= request.Qty;

            _db.StockTransactions.Add(new StockTransaction
            {
                ProductId = request.ProductId,
                Quantity = request.Qty,
                TransactionType = "OUT"
            });

            await _db.SaveChangesAsync();
            return Ok(new StockResponse
            {
                IsSuccess = true,
                Message = "Stock removed successfully",
                Data = product
            });
        }
    }
}
