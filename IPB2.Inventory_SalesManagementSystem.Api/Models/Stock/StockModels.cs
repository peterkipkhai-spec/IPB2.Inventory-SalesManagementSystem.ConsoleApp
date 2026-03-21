using IPB2.Inventory_SalesManagementSystem.DB.Models;

namespace IPB2.Inventory_SalesManagementSystem.Api.Models.Stock
{
    public class StockRequest
    {
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }

    public class StockResponse : BaseResponse<Product>
    {
    }
}
