using IPB2.Inventory_SalesManagementSystem.DB.Models;

namespace IPB2.Inventory_SalesManagementSystem.Api.Models.Sales
{
    public class CreateSaleRequest
    {
        public int StaffId { get; set; }
        public List<SaleItem> Items { get; set; }
    }

    public class SaleResponse : BaseResponse<Sale>
    {
    }
}
