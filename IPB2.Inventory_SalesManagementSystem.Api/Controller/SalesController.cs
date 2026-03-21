using IPB2.Inventory_SalesManagementSystem.DB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly InventorySalesDbContext _db;

        public SalesController()
        {
            _db = new InventorySalesDbContext();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSale(int staffId, List<SaleItem> items)
        {
            decimal total = 0;

            foreach (var item in items)
            {
                var product = await _db.Products.FindAsync(item.ProductId);

                if (product == null || product.QuantityInStock < item.Quantity)
                    return BadRequest("Invalid product or insufficient stock");

                item.Price = (decimal)product.Price;
                item.SubTotal = item.Quantity * item.Price;

                total += (decimal)item.SubTotal;

                product.QuantityInStock -= item.Quantity;
            }

            var sale = new Sale
            {
                StaffId = staffId,
                TotalAmount = total,
                SaleDate = DateTime.Now
            };

            _db.Sales.Add(sale);
            await _db.SaveChangesAsync();

            foreach (var item in items)
            {
                item.SaleId = sale.SaleId;
                _db.SaleItems.Add(item);
            }

            await _db.SaveChangesAsync();

            return Ok(sale);
        }
    }
}
