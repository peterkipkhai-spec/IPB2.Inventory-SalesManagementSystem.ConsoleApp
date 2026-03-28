using IPB2.Inventory_SalesManagementSystem.DB.Models;
using System.Collections.Generic;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Services
{
    public interface ISalesService
    {
        void CreateSale(int staffId, List<SaleItem> items);
    }
}
