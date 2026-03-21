using IPB2.Inventory_SalesManagementSystem.DB.Models;

namespace IPB2.Inventory_SalesManagementSystem.Api.Models.Suppliers
{
    public class SupplierResponse : BaseResponse<Supplier>
    {
    }

    public class SupplierPagedResponse : BaseResponse<SupplierPagedData>
    {
    }

    public class SupplierPagedData
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public List<Supplier> Data { get; set; }
    }
}
