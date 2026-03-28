namespace IPB2.Inventory_SalesManagementSystem.MVC.Features.Categories.Models
{
    public class CategoryRequest
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
