using IPB2.Inventory_SalesManagementSystem.DB.Models;
using System.Collections.Generic;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Services
{
    public interface ISupplierService
    {
        List<Supplier> GetAll();
        void Add(Supplier s);
        void Update(Supplier s);
        void Delete(int id);
    }
}
