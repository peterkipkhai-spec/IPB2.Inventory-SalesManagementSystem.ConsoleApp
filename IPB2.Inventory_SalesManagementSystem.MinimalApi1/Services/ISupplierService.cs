using IPB2.Inventory_SalesManagementSystem.DB.Models;

namespace IPB2.Inventory_SalesManagementSystem.MinimalApi1.Services
{
    public interface ISupplierService
    {
        Task<object> GetSuppliersAsync(int pageNo, int pageSize);
        Task<Supplier> CreateSupplierAsync(Supplier model);
        Task<Supplier> UpdateSupplierAsync(Supplier model);
        Task<bool> DeleteSupplierAsync(int id);
    }
}
