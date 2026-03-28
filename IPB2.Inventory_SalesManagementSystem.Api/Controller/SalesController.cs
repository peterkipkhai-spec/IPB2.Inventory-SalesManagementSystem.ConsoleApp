using IPB2.Inventory_SalesManagementSystem.Api.Models;
using IPB2.Inventory_SalesManagementSystem.Api.Models.Sales;
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
        public async Task<IActionResult> CreateSale(CreateSaleRequest request)
        {
            decimal total = 0;

            foreach (var item in request.Items)
            {
                var product = await _db.Products.FindAsync(item.ProductId);

                if (product == null || product.QuantityInStock < item.Quantity)
                {
                    return BadRequest(new SaleResponse
                    {
                        IsSuccess = false,
                        Message = "Invalid product or insufficient stock"
                    });
                }

                item.Price = (decimal)product.Price;
                item.SubTotal = item.Quantity * item.Price;

                total += (decimal)item.SubTotal;

                product.QuantityInStock -= item.Quantity;
            }

            var sale = new Sale
            {
                StaffId = request.StaffId,
                TotalAmount = total,
                SaleDate = DateTime.Now
            };

            _db.Sales.Add(sale);
            await _db.SaveChangesAsync();

            foreach (var item in request.Items)
            {
                item.SaleId = sale.SaleId;
                _db.SaleItems.Add(item);
            }

            await _db.SaveChangesAsync();

            return Ok(new SaleResponse
            {
                IsSuccess = true,
                Message = "Sale created successfully",
                Data = sale
            });
        }
    }
}
