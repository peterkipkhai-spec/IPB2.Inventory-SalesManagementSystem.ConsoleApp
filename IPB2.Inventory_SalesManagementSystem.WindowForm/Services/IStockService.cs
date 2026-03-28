namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Services
{
    public interface IStockService
    {
        void StockIn(int productId, int qty);
        void StockOut(int productId, int qty);
    }
}
