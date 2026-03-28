namespace IPB2.Inventory_SalesManagementSystem.MVC.Models
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
