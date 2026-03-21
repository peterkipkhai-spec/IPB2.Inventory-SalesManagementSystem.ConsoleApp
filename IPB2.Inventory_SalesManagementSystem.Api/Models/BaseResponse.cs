namespace IPB2.Inventory_SalesManagementSystem.Api.Models
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
