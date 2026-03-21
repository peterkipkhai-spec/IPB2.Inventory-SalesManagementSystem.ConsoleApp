using System;
using System.Collections.Generic;

namespace IPB2.Inventory_SalesManagementSystem.DB.Models;

public partial class Product
{
    public int ProductID { get; set; }
    public object ProductId { get; set; }
    public string ProductName { get; set; } = null!;

    public int? CategoryId { get; set; }
    public int CategoryID { get; set; }
    public int? SupplierId { get; set; }
    public int SupplierID { get; set; }
    public decimal? Price { get; set; }

    public int? QuantityInStock { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public virtual ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();

    public virtual Supplier? Supplier { get; set; }
    public object UnitPrice { get; set; }
}
