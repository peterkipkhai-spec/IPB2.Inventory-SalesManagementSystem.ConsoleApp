namespace IPB2.Inventory_SalesManagementSystem.Api.Models.Products
{
    public class ProductPagedResponse : BaseResponse<ProductPagedData>
    {
    }

    public class ProductPagedData
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public dynamic Data { get; set; }
    }
}
