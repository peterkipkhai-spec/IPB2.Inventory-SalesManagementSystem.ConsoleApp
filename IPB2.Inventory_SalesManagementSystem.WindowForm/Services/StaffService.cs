using System.Collections.Generic;
using System.Linq;
using IPB2.Inventory_SalesManagementSystem.DB.Models;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Services
{
    public class StaffService : IStaffService
    {
        private readonly InventorySalesDbContext _db = new InventorySalesDbContext();

        public List<Staff> GetAll()
        {
            return _db.Staffs.ToList();
        }

        public void Add(Staff staff)
        {
            _db.Staffs.Add(staff);
            _db.SaveChanges();
        }

        public void Update(Staff staff)
        {
            _db.Staffs.Update(staff);
            _db.SaveChanges();
        }

        public void Delete(int staffId)
        {
            var staff = _db.Staffs.Find(staffId);
            if (staff != null)
            {
                _db.Staffs.Remove(staff);
                _db.SaveChanges();
            }
        }
    }
}