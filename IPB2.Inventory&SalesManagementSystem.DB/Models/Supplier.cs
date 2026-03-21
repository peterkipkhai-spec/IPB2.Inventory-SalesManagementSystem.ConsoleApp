using System;
using System.Collections.Generic;

namespace IPB2.Inventory_SalesManagementSystem.DB.Models;

public partial class Supplier
{
    public int SupplierID { get; set; }   // ✅ NOT object
    public string CompanyName { get; set; }
    public int SupplierId { get; set; }
    public string? ContactName { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
