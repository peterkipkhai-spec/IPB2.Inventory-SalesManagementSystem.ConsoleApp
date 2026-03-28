using IPB2.Inventory_SalesManagementSystem.DB.Models;
using System.Collections.Generic;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Services
{
    public interface IStaffService
    {
        List<Staff> GetAll();
        void Add(Staff staff);
        void Update(Staff staff);
        void Delete(int staffId);
    }
}
