using System;
using System.Collections.Generic;

namespace IPB2.Inventory_SalesManagementSystem.DB.Models;

public partial class SaleItem
{
    public object product;
    public int SaleItemID { get; set; }
    public int SaleID { get; set; }
    public int ProductID { get; set; }   // ✅ FIX HERE
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal SubTotal { get; set; }
    public int SaleItemId { get; set; }

    public int? SaleId { get; set; }
    
    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Sale? Sale { get; set; }
}
