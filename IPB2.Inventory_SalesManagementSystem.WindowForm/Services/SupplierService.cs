using IPB2.Inventory_SalesManagementSystem.DB.Models;
using IPB2.Inventory_SalesManagementSystem.WindowForm.Data;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Services
{
	public class SupplierService
	{
		public List<Supplier> GetAll()
		{
			using var db = AppDbContextFactory.Create();
			return db.Suppliers.ToList();
		}

		public void Add(Supplier s)
		{
			using var db = AppDbContextFactory.Create();
			db.Suppliers.Add(s);
			db.SaveChanges();
		}

		public void Update(Supplier s)
		{
			using var db = AppDbContextFactory.Create();
			db.Suppliers.Update(s);
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			using var db = AppDbContextFactory.Create();
			var data = db.Suppliers.Find(id);
			if (data != null)
			{
				db.Suppliers.Remove(data);
				db.SaveChanges();
			}
		}
	}
}