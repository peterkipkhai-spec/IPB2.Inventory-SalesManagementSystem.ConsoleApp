using IPB2.Inventory_SalesManagementSystem.DB.Models;
using System.Collections.Generic;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        void Add(Product p);
        void Update(Product p);
        void Delete(int id);
    }
}
